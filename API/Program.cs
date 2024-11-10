using System.Text;
using Amazon.S3;
using API.BU.Services;
using API.Data;
using API.Data.Models;
using API.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.ModelBuilder;
using Stripe;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAllOrigins",
    builder =>
    {
      builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
    });
});
builder.Services.AddControllers().AddOData(options =>
{
  var odataBuilder = new ODataConventionModelBuilder();
  odataBuilder.EntitySet<User>("Users");

  options.Select().Filter().OrderBy().Expand().SetMaxTop(100).Count();
});

builder.Services.AddRepository();
builder.Services.AddBu();
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.AddSingleton<IAmazonS3>(sp =>
{
  var awsOptions = builder.Configuration.GetSection("AWS").Get<AwsOptions>();
  return new AmazonS3Client(awsOptions?.AccessKey, awsOptions?.SecretKey, Amazon.RegionEndpoint.GetBySystemName(awsOptions?.Region));
});
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
       {
         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddJwtBearer(options =>
       {
         options.TokenValidationParameters = new TokenValidationParameters
         {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = jwtSettings["Issuer"],
           ValidAudience = jwtSettings["Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
         };
       });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EBayDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
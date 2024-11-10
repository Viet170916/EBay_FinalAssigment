using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.BU.Services.Interfaces;
using API.Data.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.BU.Services.Implementations;

public class UserService(IUserRepository userRepository, IConfiguration configuration) : IUserService
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IConfiguration _configuration = configuration;

  public string GenerateToken(string supabaseId, string role)
  {
    
    var jwtSettings = _configuration.GetSection("JwtSettings");
    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, supabaseId),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim(ClaimTypes.Role, role),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(issuer: jwtSettings["Issuer"],
      audience: jwtSettings["Audience"],
      claims: claims,
      expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
      signingCredentials: creds);
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
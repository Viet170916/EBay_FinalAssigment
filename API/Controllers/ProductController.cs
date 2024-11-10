using Amazon.S3;
using Amazon.S3.Model;
using API.BU.Services.Interfaces;
using API.Data.Models;
using API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(
  IAmazonS3 s3Client,
  IOptions<AwsOptions> awsOptions,
  IProductService service,
  IProductRepository repository
)
  : ControllerBase
{
  private readonly string _bucketName = awsOptions.Value.BucketName;

  [HttpGet] public async Task<IActionResult> GetProducts()
  {
    try
    {
      var products = await repository.GetAllQueryable().ToListAsync();
      foreach (var product in products)
      {
        var request = new GetPreSignedUrlRequest
        {
          BucketName = _bucketName, Key = product.Url, Expires = DateTime.UtcNow.AddHours(1)
        };
        product.Url = await s3Client.GetPreSignedURLAsync(request);
      }

      return Ok(products);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error: " + ex.Message);
      return StatusCode(400, "Something went wrong");
    }
  }

  [HttpGet("{id}")] public async Task<IActionResult> GetProduct(int id)
  {
    var product = await repository.GetById(id);
    return Ok(product);
  }

  [HttpPost("create")] public async Task<IActionResult> CreateProduct(ProductRequest productRequest)
  {
    var product = new Product()
    {
      Title = productRequest.Title,
      Description = productRequest.Description,
      UserId = productRequest.UserId,
      Url = productRequest.Url,
      Price = productRequest.Price,
    };
    await repository.Add(product);
    return Ok(new { Message = "Create Successfully", });
  }

  [HttpPut("update")] public async Task<IActionResult> UpdateProduct(ProductRequest productRequest)
  {
    var product = new Product()
    {
      Title = productRequest.Title,
      Description = productRequest.Description,
      UserId = productRequest.UserId,
      Url = productRequest.Url,
      Price = productRequest.Price,
    };
    await repository.Update(product);
    return Ok(new { Message = "Update Successfully", });
  }

  [HttpDelete("delete")] public async Task<IActionResult> DeleteProduct(int productId)
  {
    await repository.Remove(productId);
    return Ok(new { Message = "Delete Successfully", });
  }
}

public class ProductRequest
{
  public int? Id { get; set; }
  public string Title { get; set; }
  public string? Description { get; set; }
  public string Url { get; set; }
  public decimal Price { get; set; }
  public int? UserId { get; set; }
}
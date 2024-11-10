using API.BU.Services.Interfaces;
using API.Data.Models;
using API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductService service, IProductRepository repository) : ControllerBase
{
  [HttpGet] public async Task<IActionResult> GetProducts()
  {
    var products = await repository.GetAll();
    return Ok(products);
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
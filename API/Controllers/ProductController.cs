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

  [HttpPost] public async Task<IActionResult> CreateProduct(Product product)
  {
    await repository.Add(product);
    return Ok();
  }
}
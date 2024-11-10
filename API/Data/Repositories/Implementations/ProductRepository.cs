using API.Data.Models;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implementations;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
  public ProductRepository(EBayDbContext context) : base(context) { }
}
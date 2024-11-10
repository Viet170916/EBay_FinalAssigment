using API.BU.Services.Interfaces;
using API.Data.Repositories.Interfaces;

namespace API.BU.Services.Implementations;

public class ProductService(IProductRepository userRepository) : IProductService { }
using API.BU.Services.Implementations;
using API.BU.Services.Interfaces;
using API.Data.Repositories.Interfaces;

namespace API.BU.Services;

public static class ServicesOptionCollection
{
  public static void AddBu(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddTransient<IUserService, UserService>();
    serviceCollection.AddTransient<IProductService, ProductService>();
  }
}
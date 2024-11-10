using API.BU.Services.Implementations;
using API.BU.Services.Interfaces;

namespace API.BU.Services;

public static class ServicesOptionCollection
{
  public static void AddBu(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddTransient<IUserService, UserService>();
  }
}
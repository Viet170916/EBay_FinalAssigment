using API.Data.Repositories.Implementations;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories;

public static class RepositoryOptionCollection
{
  public static void AddRepository(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddTransient<IUserRepository, UserRepository>();
  }
}
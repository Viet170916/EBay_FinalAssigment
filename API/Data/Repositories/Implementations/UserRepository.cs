using API.Data.Models;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implementations;

public class UserRepository: GenericRepository<User>, IUserRepository
{
  public UserRepository(EBayDbContext context) : base(context) { }
}
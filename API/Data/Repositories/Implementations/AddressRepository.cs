using API.Data.Models;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implementations;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(EBayDbContext context) : base(context)
    {
    }
}

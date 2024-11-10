using API.Data.Models;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implementations
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EBayDbContext context) : base(context)
        {
        }
    }
}

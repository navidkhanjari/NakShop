using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;
using System;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }
        public async Task<Order?> GetCurrentUserOrder(Guid userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pending);
        }

   
    }
}

using Common.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order?> GetCurrentUserOrder(Guid userId);
    }
}

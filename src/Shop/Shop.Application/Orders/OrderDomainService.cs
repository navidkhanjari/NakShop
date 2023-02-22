using Shop.Domain.OrderAgg.Services;
using Shop.Domain.SellerAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly ISellerRepository _repository;

        public OrderDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool InventoryIsLessThan(Guid inventoryId, long count)
        {
            var inventory = _repository.GetInventoryById(inventoryId).Result;
            if (inventory == null)
                return true;

            return inventory.Count < count;
        }

        public InventoryResult GetInventory(Guid id)
        {
            return _repository.GetInventoryById(id).Result;

        }
    }
}

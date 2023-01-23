using Common.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg.Repository
{
    public interface ISellerRepository:IBaseRepository<Seller>
    {
        Task<InventoryResult> GetInventoryById(Guid id);
        void Delete(Seller seller);
    }
    public class InventoryResult
    {
        public Guid Id { get; set; }
        public Guid SellerId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
    }
}

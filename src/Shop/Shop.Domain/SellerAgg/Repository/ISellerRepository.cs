using Common.Domain.Repository;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg.Repository
{
    public interface ISellerRepository:IBaseRepository<Seller>
    {
        Task<InventoryResult> GetInventoryById(long id);
        void Delete(Seller seller);
    }
    public class InventoryResult
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
    }
}

using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.ProductAgg
{
        public class ProductRepository : BaseRepository<Product>, IProductRepository
        {
            public ProductRepository(ShopContext context) : base(context)
            {
            }
        }
    
}

using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg
{
 
        internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
        {
            public SellerRepository(ShopContext context) : base(context)
            {
            }

            public async void Delete(Seller seller)
            {
                throw new NotImplementedException();
            }

            public async Task<InventoryResult?> GetInventoryById(Guid id)
            {
                return await Context.Inventories.Where(r => r.Id == id)
                    .Select(i => new InventoryResult()
                    {
                        Count = i.Count,
                        Id = i.Id,
                        Price = i.Price,
                        ProductId = i.ProductId,
                        SellerId = i.SellerId
                    }).FirstOrDefaultAsync();
            }

        }
    
}

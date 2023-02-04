using Common.Domain.Repository;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }
    }

}

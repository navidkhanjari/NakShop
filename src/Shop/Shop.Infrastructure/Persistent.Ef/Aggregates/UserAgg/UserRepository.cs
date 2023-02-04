using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.UserAgg
{
  
        internal class UserRepository : BaseRepository<User>, IUserRepository
        {
            public UserRepository(ShopContext context) : base(context)
            {
            }
        }
    
}


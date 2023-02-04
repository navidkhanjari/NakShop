using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.RoleAgg
{
  
        internal class RoleRepository : BaseRepository<Role>, IRoleRepository
        {
            public RoleRepository(ShopContext context) : base(context)
            {
            }

        public Task Delete(Role role)
        {
            throw new System.NotImplementedException();
        }
    }
    
}

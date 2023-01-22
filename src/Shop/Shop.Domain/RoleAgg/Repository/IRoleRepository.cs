using Common.Domain.Repository;

using System.Threading.Tasks;

namespace Shop.Domain.RoleAgg.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task Delete(Role role);
    }
}

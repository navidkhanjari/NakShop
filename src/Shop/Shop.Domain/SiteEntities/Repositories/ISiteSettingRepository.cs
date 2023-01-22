using Common.Domain.Repository;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities.Repositories
{
    public interface ISiteSettingRepository : IBaseRepository<SiteSetting>
    {
        Task<SiteSetting?> GetFirst();
    }
}

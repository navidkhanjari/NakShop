using Common.Domain.Repository;


namespace Shop.Domain.SiteEntities.Repositories
{
    public interface IContactUsRepository : IBaseRepository<ContactUs>
    {
        void Delete(ContactUs contactUs);
    }
}

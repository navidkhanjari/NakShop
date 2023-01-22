namespace Shop.Domain.CategoryAgg
{
    public interface ICategoryDomainService
    {
        public bool IsSlugExist(string slug);
    }
}
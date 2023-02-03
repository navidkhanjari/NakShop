using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities
{
    public class Banner : BaseEntity
    {
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public BannerPosition Position { get; private set; }

        public Banner(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Edit(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Guard(string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        }
    }

    public enum BannerPosition
    {
        بالای_اسلایدر,
        سمت_چپ_اسلایدر,
        سمت_راست_شگفت_انگیز_ها,
        بنر_های_کوچک_وسط_صفحه,
        بنرهای_بزرگ_وسط_صفحه
    }
}

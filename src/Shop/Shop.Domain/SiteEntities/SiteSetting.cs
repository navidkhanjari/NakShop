using Common.Domain;
using Common.Domain.ValueObjects;
using Shop.Domain.SiteEntities.ValueObjects;


namespace Shop.Domain.SiteEntities
{
   public class SiteSetting:BaseEntity
    {
        private SiteSetting()
        {
        }
        public SeoData? MainPageSeoData { get; private set; }
        public string? SiteName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? FooterText { get; private set; }
        public SocialNetworks? SocialNetworks { get; private set; }
        public string? MainPageProductCategory { get; private set; }
        public string? AboutUs { get; private set; }
        public string? SiteRules { get; private set; }
        public int SitePercentageFee { get; private set; }
        public string? CategoriesSelectedId { get; private set; }
        public string? Address { get; private set; }


        public SiteSetting(SeoData? mainPageSeoData, string? email, string? phoneNumber, string? footerText,
            SocialNetworks? socialNetworks, string? mainPageProductCategory, int sitePercentageFee,
            string? aboutUs, string? siteRules, string? siteName, string categoriesSelectedId, string address)
        {
            MainPageSeoData = mainPageSeoData;
            Email = email;
            PhoneNumber = phoneNumber;
            FooterText = footerText;
            SocialNetworks = socialNetworks;
            MainPageProductCategory = mainPageProductCategory;
            SitePercentageFee = sitePercentageFee;
            AboutUs = aboutUs;
            SiteRules = siteRules;
            SiteName = siteName;
            CategoriesSelectedId = categoriesSelectedId;
            Address = address;

        }
        public void Edit(SeoData? mainPageSeoData, string? email, string? phoneNumber, string? footerText,
            SocialNetworks? socialNetworks, string? mainPageProductCategory, int sitePercentageFee,
            string? aboutUs, string? siteRules, string? siteName, string categoriesSelectedId, string address)
        {
            MainPageSeoData = mainPageSeoData;
            Email = email;
            PhoneNumber = phoneNumber;
            FooterText = footerText;
            SocialNetworks = socialNetworks;
            MainPageProductCategory = mainPageProductCategory;
            SitePercentageFee = sitePercentageFee;
            AboutUs = aboutUs;
            SiteRules = siteRules;
            SiteName = siteName;
            CategoriesSelectedId = categoriesSelectedId;
            Address = address;

        }
    }
}

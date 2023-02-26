using System.ComponentModel.DataAnnotations;
using Common.Domain.ValueObjects;
using Shop.Domain.SiteEntities.ValueObjects;

namespace Shop.Web.ViewModels {

    public class SocialNetworksViewModel
    {
        [Display(Name = "اینستاگرام")]
        public string? Instagram { get; set; }
        [Display(Name = "لینکدین")]
        public string? LinkeDin { get; set; }

        [Display(Name = "فیسبوک")]
        public string? FaceBook { get; set; }

        [Display(Name = "تویتر")]
        public string? Twitter { get; set; }

        [Display(Name = "تلگرام")]
        public string? Telegram { get; set; }

        public SocialNetworks Map()
        {
            return new SocialNetworks(Instagram, LinkeDin, FaceBook, Twitter, Telegram);
        }
        public static SocialNetworksViewModel ConvertToViewModel(SocialNetworks seoData)
        {
            if (seoData == null)
                return new SocialNetworksViewModel();

            return new SocialNetworksViewModel()
            {
                FaceBook = seoData.FaceBook,
                Instagram = seoData.Instagram,
                LinkeDin = seoData.LinkeDin,
                Telegram = seoData.Telegram,
                Twitter = seoData.Twitter
            };
        }
    }
}
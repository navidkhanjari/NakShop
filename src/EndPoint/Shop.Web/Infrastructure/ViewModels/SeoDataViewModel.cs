using System.ComponentModel.DataAnnotations;
using Common.Domain.ValueObjects;

namespace Shop.Web.ViewModels
{
    public class SeoDataViewModel
    {
        public string MetaTitle { get; set; }
        [DataType(DataType.MultilineText)]
        public string? MetaDescription { get; set; }

        [Display(Name = "Meta KeyWords (Test,Test2,Test3)")]
        public string? MetaKeyWords { get; set; }

        public bool? IndexPage { get; set; } = true;
        public string? Canonical { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Schema { get; set; }

        public SeoData MapToSeoData()
        {
            return new SeoData(MetaKeyWords, MetaDescription, MetaTitle, Canonical,IndexPage
                ,Schema);
        }
        public static SeoDataViewModel ConvertSeoDataToViewModel(SeoData seoData)
        {
            if (seoData == null)
                return new SeoDataViewModel();

            return new SeoDataViewModel()
            {
                MetaDescription = seoData.MetaDescription,
                MetaKeyWords = seoData.MetaKeyWords,
                MetaTitle = seoData.MetaTitle,
                Canonical = seoData.Canonical,
                IndexPage = seoData.IndexPage,
                Schema = seoData.Schema
            };
        }
    }
}
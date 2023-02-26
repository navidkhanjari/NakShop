using System;
using System.ComponentModel.DataAnnotations;

namespace ShopUi.ViewModels.Addresses
{
    public class AddAddressViewModel
    {
        [Display(Name = "نام گیرنده")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی گیرنده")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Family { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PostalCode { get; set; }

        [Display(Name = "آدرس کامل")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PostalAddress { get; set; }

        [Display(Name = "کد ملی گیرنده")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string NationalCode { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Shire { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string City { get; set; }
    }

    public class EditAddressViewModel : AddAddressViewModel
    {
        public Guid Id { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.Validation;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;
using Shop.Web.Infrastructure.RazorUtils;

namespace Shop.Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : BaseRazor
    {
        private readonly IUserFacade _userFacade;
        public RegisterModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }
        #region Properties
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression((@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$"), ErrorMessage = "شماره تماس وارد شده معتبر نمی باشد")]
        public string PhoneNumber { get; set; }
        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = ValidationMessages.MinLength)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = ValidationMessages.MinLength)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string ConfirmPassword { get; set; }
        #endregion

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var res = await _userFacade.RegisterUser(new RegisterUserCommand(new PhoneNumber(PhoneNumber),Password));
            if (res.Status == OperationResultStatus.Success)
                res.Message = "ثبت نام با موفقیت انجام شد";

            return RedirectAndShowAlert(res, RedirectToPage("Login"));
        }
    }
}

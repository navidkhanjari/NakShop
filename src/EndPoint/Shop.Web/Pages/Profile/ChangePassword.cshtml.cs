using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Users.ChangePassword;
using Shop.Presentation.Facade.Users;
using Shop.Web.Infrastructure;
using Shop.Web.Infrastructure.RazorUtils;

namespace Shop.Web.Pages.Profile
{
    [BindProperties]
    public class ChangePasswordModel : BaseRazor
    {
        private readonly IUserFacade _userFacade;

        public ChangePasswordModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }
        [Display(Name = "کلمه عبور فعلی ")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = ValidationMessages.MinLength)]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = ValidationMessages.MinLength)]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = ValidationMessages.MinLength)]
        [Compare("NewPassword", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _userFacade.ChangeUserPassword(
                new ChangeUserPasswordCommand(User.GetUserId(), NewPassword, CurrentPassword));

            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}

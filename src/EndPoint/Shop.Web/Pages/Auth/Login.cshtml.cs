using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Application.SecurityUtil;
using Common.Application.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Orders.AddItem;
using Shop.Presentation.Facade.Orders;
using Shop.Presentation.Facade.Users;
using Shop.Web.Infrastructure.RazorUtils;
using Shop.Web.Infrastructure.ShopCart;

namespace Shop.Web.Pages.Auth
{
    [BindProperties]
   
    public class LoginModel : BaseRazor
    {
        private readonly IUserFacade _userFacade;
        private readonly IOrderFacade _orderFacade;
        private readonly ShopCartManager _shopCartManager;
        public LoginModel(IUserFacade userFacade, IOrderFacade orderFacade,ShopCartManager shopCartManager)
        {
           _orderFacade = orderFacade;
            _userFacade = userFacade;
            _shopCartManager = shopCartManager;
        }
        [RegularExpression((@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$"), ErrorMessage = "شماره تماس وارد شده معتبر نمی باشد")]
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MinLength(6, ErrorMessage = ValidationMessages.MinLength)]
        public string Password { get; set; }
    

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public async Task<IActionResult> OnPost()
        {
            var user = await _userFacade.GetUserByPhoneNumber(PhoneNumber);
            if (user == null)
            {
                ErrorAlert("کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }
            var password = PasswordHelper.EncodePasswordMd5(Password);
            if (user.Password != password)
            {
                ErrorAlert("کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }
            var claims = new List<Claim>()
              {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                        new Claim(ClaimTypes.Name,user?.Name),
              };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = RememberMe,
            };
            await HttpContext.SignInAsync(principal, properties);
            await SetShopCart(user.Id);
            SuccessAlert("ورود با موفقیت انجام شد . خوش آمدید");
            return LocalRedirect(ReturnUrl);
        }

        private async Task SetShopCart(Guid userId)
        {
            var shopCart = _shopCartManager.GetShopCart();
            if (shopCart == null)
                return;

            try
            {
                foreach (var item in shopCart.Items)
                {
                    var command = new AddOrderItemCommand(item.InventoryId, item.Count, userId);
                    await _orderFacade.AddOrderItem(command);
                }
                HttpContext.Response.Cookies.Delete("shop-cart");
            }
            catch
            {

            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.ViewComponents
{
    public class SiteFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("SiteFooter");
        }
    }
}

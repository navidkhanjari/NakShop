using System.Collections.Generic;
using System.Linq;

namespace Shop.Web.ViewModels.ShopCart
{

    public class ShopCartViewModel
    {
        public List<ShopCartItemViewModel> Items { get; set; }
        public int Price => Items.Sum(s => s.Price * s.Count);
        public int TotalPrice => Items.Sum(s => s.TotalPrice);
        public int TotalCount { get; set; }
    }
}
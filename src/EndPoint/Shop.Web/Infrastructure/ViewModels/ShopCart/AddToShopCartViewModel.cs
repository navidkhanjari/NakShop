using System;

namespace Shop.Web.ViewModels.ShopCart
{

    public class AddToShopCartViewModel
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public string ImageName { get; set; }
        public string ProductSlug { get; set; }
        public string ProductTitle { get; set; }
        public string ShopName { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int Count { get; set; }
    }
}
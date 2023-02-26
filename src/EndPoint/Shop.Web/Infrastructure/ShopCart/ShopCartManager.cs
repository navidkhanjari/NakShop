using AutoMapper;
using CookieManager;
using Microsoft.AspNetCore.Http;
using Shop.Query.Orders.DTOs;
using Shop.Web.ViewModels.ShopCart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Web.Infrastructure.ShopCart
{

    public class ShopCartManager
    {
        private readonly ICookieManager _cookieManager;
        private const string CookieShopCartName = "shop-cart";
        private readonly IMapper _mapper;
        public ShopCartManager(ICookieManager cookieManager, IMapper mapper)
        {
            _cookieManager = cookieManager;
            _mapper = mapper;
        }

        public ShopCartViewModel? GetShopCart()
        {
            return _cookieManager.Get<ShopCartViewModel?>(CookieShopCartName);
        }
        public void AddToShopCart(AddToShopCartViewModel viewModel)
        {
            var shopCart = _cookieManager.Get<ShopCartViewModel?>(CookieShopCartName);
            var newItem = _mapper.Map<ShopCartItemViewModel>(viewModel);
            newItem.Product = new OrderProduct()
            {
                Title = viewModel.ProductTitle,
                ImageName = viewModel.ImageName,
                Slug = viewModel.ProductSlug
            };
            newItem.Id = GenerateId();
            if (shopCart == null)
            {
                var data = new ShopCartViewModel()
                {
                    TotalCount = viewModel.Count,
                    Items = new List<ShopCartItemViewModel>()
                {
                    newItem
                }
                };
                SetCookie(data);
            }
            else
            {
                if (shopCart.Items.Any(c => c.InventoryId == newItem.InventoryId))
                {
                    var oldItem = shopCart.Items.First(c => c.InventoryId == newItem.InventoryId);
                    oldItem.Count += newItem.Count;
                }
                else
                {
                    shopCart.Items.Add(newItem);
                }
                shopCart.TotalCount += newItem.Count;
                SetCookie(shopCart);
            }
        }
        private Guid GenerateId()
        {
            var id = Guid.NewGuid();
            return id;
        }
        public void RemoveItem(Guid id)
        {
            var shopCart = _cookieManager.Get<ShopCartViewModel?>(CookieShopCartName);
            if (shopCart == null)
                return;
            var item = shopCart.Items.FirstOrDefault(f => f.Id == id);
            if (item == null)
                return;

            shopCart.TotalCount -= item.Count;
            shopCart.Items.Remove(item);
            SetCookie(shopCart);
        }




        private void SetCookie(ShopCartViewModel shopCart)
        {
            _cookieManager.Set(CookieShopCartName, shopCart, new CookieOptions()
            { Expires = DateTimeOffset.Now.AddDays(10), HttpOnly = true });
        }

    }
}
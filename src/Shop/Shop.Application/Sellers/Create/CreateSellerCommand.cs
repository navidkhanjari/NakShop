using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommand : IBaseCommand
    {
        public CreateSellerCommand(Guid userId, string shopName)
        {
            UserId = userId;
            ShopName = shopName;
        }
        public Guid UserId { get; private set; }
        public string ShopName { get; private set; }
    }
}

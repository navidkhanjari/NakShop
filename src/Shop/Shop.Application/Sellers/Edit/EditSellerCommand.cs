using Common.Application;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(Guid Id, string ShopName, SellerStatus Status) : IBaseCommand;
}

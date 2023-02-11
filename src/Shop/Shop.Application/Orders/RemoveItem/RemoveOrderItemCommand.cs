using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(Guid UserId, Guid ItemId) : IBaseCommand;
}

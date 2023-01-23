using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public record IncreaseOrderItemCountCommand(Guid UserId, Guid ItemId) : IBaseCommand;
 
}


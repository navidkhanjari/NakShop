using Common.Application;
using System;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public record DecreaseOrderItemCountCommand(Guid UserId, Guid ItemId) : IBaseCommand;
}

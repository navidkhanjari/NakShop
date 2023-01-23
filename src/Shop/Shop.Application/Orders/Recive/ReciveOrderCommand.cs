using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.Recive
{
    public record ReceiveOrderCommand(Guid Id, Guid UserId) : IBaseCommand;
}

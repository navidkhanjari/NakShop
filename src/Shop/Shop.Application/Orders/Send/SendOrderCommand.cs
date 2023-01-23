using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.Send
{
    public record SendOrderCommand(Guid OrderId, string TrackingCode) : IBaseCommand;
}

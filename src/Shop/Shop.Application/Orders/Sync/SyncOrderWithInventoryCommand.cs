using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.Sync
{

    public record SyncOrderWithInventoryCommand(Guid UserId) : IBaseCommand<bool>;
}

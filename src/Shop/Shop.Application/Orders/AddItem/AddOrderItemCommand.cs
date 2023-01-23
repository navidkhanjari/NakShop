using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommand : IBaseCommand
    {
        public AddOrderItemCommand(Guid inventoryId, int count, Guid userId)
        {
            InventoryId = inventoryId;
            Count = count;
            UserId = userId;
        }

        public Guid InventoryId { get; private set; }
        public int Count { get; private set; }
        public Guid UserId { get; private set; }
    }
}
using Common.Application;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Sellers.Inventories
{
    public interface ISellerInventoryFacade
    {
        Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
        Task<OperationResult> AddInventory(EditInventoryCommand command);
    }
}

using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Sellers.Inventories
{
    internal class SellerInventoryFacade : ISellerInventoryFacade
    {
        private IMediator _mediator;

        public SellerInventoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddInventory(EditInventoryCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}

using Common.Application;
using Shop.Domain.OrderAgg;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommandHandler : IBaseCommandHandler<DecreaseOrderItemCountCommand>
    {
        private readonly IOrderRepository _repository;

        public DecreaseOrderItemCountCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.DecreaseItemCount(request.ItemId,1);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

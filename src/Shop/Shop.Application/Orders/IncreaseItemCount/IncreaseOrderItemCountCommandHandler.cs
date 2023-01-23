using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderDomainService _domainService;
        public IncreaseOrderItemCountCommandHandler(IOrderRepository repository, IOrderDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.IncreaseItemCount(request.ItemId, 1, _domainService);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
 
}


using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Sync
{
    public class SyncOrderWithInventoryCommandHandler : IBaseCommandHandler<SyncOrderWithInventoryCommand, bool>
    {
        private readonly IOrderDomainService _domainService;
        private readonly IOrderRepository _repository;

        public SyncOrderWithInventoryCommandHandler(IOrderDomainService domainService, IOrderRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(SyncOrderWithInventoryCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetCurrentUserOrder(request.UserId);
            if (order == null)
                return OperationResult<bool>.NotFound();

            var isChanged = order.SyncOrderWithInventory(_domainService);
            if (isChanged)
                await _repository.Save();
            return OperationResult<bool>.Success(isChanged);
        }
    }
}

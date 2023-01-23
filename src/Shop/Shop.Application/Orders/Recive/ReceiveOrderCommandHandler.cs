using Common.Application;
using Shop.Domain.OrderAgg;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Recive
{
    internal class ReceiveOrderCommandHandler : IBaseCommandHandler<ReceiveOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ReceiveOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(ReceiveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetTracking(request.Id);
            if (order == null || order.UserId != request.UserId)
                return OperationResult.NotFound();

            order.ReceiveOrder();
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}

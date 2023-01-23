using Common.Application;
using Shop.Domain.OrderAgg;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Send
{
    internal class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public SendOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetTracking(request.OrderId);
            if (order == null)
                return OperationResult.NotFound();

            order.SendOrder(request.TrackingCode);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}

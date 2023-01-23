using Common.Application;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Finally
{
    public record FinallyOrderCommand(Guid Id) : IBaseCommand;

    public class FinallyOrderCommandHandler : IBaseCommandHandler<FinallyOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public FinallyOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
        {

            var order = await _repository.GetTracking(request.Id);
            if (order == null)
                return OperationResult.NotFound();

            order.FinallyOrder();
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

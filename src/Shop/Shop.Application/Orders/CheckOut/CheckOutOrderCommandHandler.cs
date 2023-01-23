﻿using Common.Application;
using Shop.Domain.OrderAgg;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public CheckOutOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            var address = new OrderAddress(request.Shire, request.City, request.PostalCode,
                request.PostalAddress, request.PhoneNumber, request.Name,
                request.Family);
            currentOrder.Checkout(address, request.DeliveryInfo);

            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Services;
using Shop.Domain.SellerAgg.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IOrderDomainService _domainService;
        public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository, IOrderDomainService domainService)
        {
            _repository = repository;
            _sellerRepository = sellerRepository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
            if (inventory == null)
                return OperationResult.NotFound();

            if (inventory.Count < request.Count)
                return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

            var order = await _repository.GetCurrentUserOrder(request.UserId);
            if (order == null)
            {
                order = new Order(request.UserId);
                await _repository.AddAsync(order);
            }

            order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price
                , inventory.DiscountPercentage), _domainService);


            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
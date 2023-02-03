using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInventory
{
    internal class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainService;

        public AddSellerInventoryCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            var inventory = new SellerInventory(request.ProductId, request.Count, request.Price, request.DiscountPercentage);
            seller.AddInventory(inventory, _domainService);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

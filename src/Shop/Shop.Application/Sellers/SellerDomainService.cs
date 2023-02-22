using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;
        private readonly IProductRepository _productRepository;
        public SellerDomainService(ISellerRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

       

        public bool SellerIsExist(Guid userId)
        {
            return _repository.Exists(f => f.UserId == userId);

        }

        public bool ProductNotFound(Guid productId)
        {
            return !_productRepository.Exists(e => e.Id == productId);
        }
    }
}

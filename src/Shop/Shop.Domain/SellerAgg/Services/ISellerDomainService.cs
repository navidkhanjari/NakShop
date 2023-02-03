using System;

namespace Shop.Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
      
        bool SellerIsExist(Guid userId);
        bool ProductNotFound(Guid productId);
    }
}

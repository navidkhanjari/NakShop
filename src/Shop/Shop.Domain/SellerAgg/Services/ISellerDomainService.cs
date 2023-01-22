using System;

namespace Shop.Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        bool NationalCodeExistInDataBase(string nationalCode);
        bool SellerIsExist(Guid userId);
        bool ProductNotFound(Guid productId);
    }
}

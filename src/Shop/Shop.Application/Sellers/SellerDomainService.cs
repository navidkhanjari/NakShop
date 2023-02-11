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
        public bool ProductNotFound(Guid productId)
        {
            throw new NotImplementedException();
        }

        public bool SellerIsExist(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}

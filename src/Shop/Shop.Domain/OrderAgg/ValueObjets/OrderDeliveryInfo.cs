using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjets
{
        public class OrderDeliveryInfo : ValueObject
        {
            public OrderDeliveryInfo(string shippingType, int shippingCost)
            {
                ShippingType = shippingType;
                ShippingCost = shippingCost;
            }

            public OrderDeliveryInfo SetTrackingCode(string postTrackingCode)
            {
                return new OrderDeliveryInfo(ShippingType, ShippingCost)
                {
                    PostTrackingCode = postTrackingCode
                };
            }
            public string ShippingType { get; private set; }
            public int ShippingCost { get; private set; }
            public string? PostTrackingCode { get; private set; }

        }
    
}

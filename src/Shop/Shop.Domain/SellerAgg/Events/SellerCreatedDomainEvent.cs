using Common.Domain;
using System;

namespace Shop.Domain.SellerAgg.Events
{
    public class SellerCreatedDomainEvent : BaseDomainEvent
    {
        public Guid UserId { get; set; }
        public string ShopName { get; set; }
    }
}

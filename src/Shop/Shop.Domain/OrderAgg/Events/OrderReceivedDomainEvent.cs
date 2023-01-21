using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Events
{
    public class OrderReceivedDomainEvent : BaseDomainEvent
    {
        public OrderReceivedDomainEvent(Guid orderId, DateTime occurredDate)
        {
            OrderId = orderId;
            OccurredDate = occurredDate;
        }

        public Guid OrderId { get; private set; }
        public DateTime OccurredDate { get; private set; }
    }
}

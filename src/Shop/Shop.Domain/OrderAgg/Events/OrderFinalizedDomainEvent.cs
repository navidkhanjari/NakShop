using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Events
{
    public class OrderFinalizedDomainEvent : BaseDomainEvent
    {
        public Guid OrderId { get; set; }
        public DateTime FinallyDate { get; set; }
    }
}

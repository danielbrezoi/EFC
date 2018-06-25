using ClientOrder.Domain.Tools;
using System;

namespace ClientOrder.Domain.Entities
{
    public class OrderDetails : ClientChangeTracker
    {
        public Guid OrderDetailsId { get; set; }

        public string Details { get; set; }

        //Navigation property for one to one relation
        public Order Order { get; set; }
        //Foreign key for one to one relation
        public Guid OrderId { get; set; }
    }
}

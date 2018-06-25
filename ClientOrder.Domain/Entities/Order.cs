using ClientOrder.Domain.Tools;
using System;
using System.Collections.Generic;

namespace ClientOrder.Domain.Entities
{
    public class Order : ClientChangeTracker
    {
        public Guid OrderId { get; set; } 

        public string Name { get; set; }

        //Navigation property for one to may relation
        public IEnumerable<Product> Products { get; set; }

        //Navigation property for one-to-one reltion
        public OrderDetails OrderDetails { get; set; }
    }
}

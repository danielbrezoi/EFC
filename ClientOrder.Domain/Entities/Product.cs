using ClientOrder.Domain.Tools;
using System;

namespace ClientOrder.Domain.Entities
{
    public class Product : ClientChangeTracker
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}
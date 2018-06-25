using ClientOrder.Domain.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientOrder.Domain.Entities
{
    public class Address : ClientChangeTracker
    {
        public Guid AddressId { get; set; }

        [Required]
        public string FullAddress { get; set; }

        //Navigation to table extra model for many to many relation
        public ICollection<ClientAddress> Client { get; set; }
    }
}

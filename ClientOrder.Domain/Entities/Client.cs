using ClientOrder.Domain.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientOrder.Domain.Entities
{
    public class Client : ClientChangeTracker
    {
        public Guid ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        //Navigation property for many to many relation
        public ICollection<ClientAddress> Address { get; set; }
    }
}

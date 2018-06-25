using ClientOrder.Domain.Tools;
using System;

namespace ClientOrder.Domain.Entities
{

    // This class will create the many to many relation between Address and Client
    public class ClientAddress : ClientChangeTracker
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

    }
}

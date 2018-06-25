using ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ClientOrder.Service.CudDto.CreateDto
{
    public class UpdateClientDto
    {
        public Guid ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ClientAddress> Address { get; set; }
    }
}

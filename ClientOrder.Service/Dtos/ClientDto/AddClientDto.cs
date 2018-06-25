using ClientOrder.Domain.Entities;
using System.Collections.Generic;

namespace ClientOrder.Service.CudDto.CreateDto
{
    public class AddClientDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ClientAddress> Address { get; set; }
    }
}

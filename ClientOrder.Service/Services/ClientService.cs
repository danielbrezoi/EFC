using System;
using System.Linq;
using System.Collections.Generic;
using ClientOrder.Data.Context;
using ClientOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientOrder.Service.ClientServicies
{

    public class ClientService : RepoService
    {
        public ClientService(ClientOrderContext context)
            : base(context) { }

        public List<KeyValuePair<Guid,string>> GetClientsReferenceList()
            => Context.Clients.Select(c => new { c.ClientId, c.LastName })
                              .ToDictionary(t => t.ClientId, t => t.LastName).ToList();

        public Client LoadClientGraph(Guid id)
            => Context.Clients
                      .Include(c => c.Address)
                      .FirstOrDefault(c => c.ClientId == id);

        public void Save(Client entity)
            => base.Save(entity);

        public void CascadeDelete(int id)
            => base.CascadeDelete(Context.Clients.Find(id));
    }
}

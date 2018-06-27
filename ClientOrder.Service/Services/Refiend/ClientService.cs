using System;
using System.Linq;
using System.Collections.Generic;
using ClientOrder.Data.Context;
using ClientOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientOrder.Service.ClientServicies
{

    public class ClientService : RepoBaseService
    {
        public ClientService(ClientOrderContext context)
            : base(context) { }

        public List<KeyValuePair<Guid, string>> GetClientsReferenceList()
            => Context.Clients.Select(c => new { c.ClientId, c.LastName })
                              .ToDictionary(t => t.ClientId, t => t.LastName).ToList();

        public Client LoadClientGraph(Guid id)
        {
            var a = Context.Clients
                      .Include(c => c.Address)
                      .FirstOrDefault(c => c.ClientId == id);
            return a;
        }

        public void Save(Client entity)
            => base.Save(entity);

        public void CascadeDelete(Guid id)
            => base.CascadeDelete(Context.Clients.Find(id));
    }
}

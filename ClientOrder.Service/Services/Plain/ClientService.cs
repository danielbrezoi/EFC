using ClientOrder.Data.Context;
using ClientOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientOrder.Service.Plain
{
    public class ClientService
    {
        private readonly ClientOrderContext context;
        public ClientService(ClientOrderContext context) 
            => this.context = context;

        public List<Client> GetAllClients()
            => context.Clients.ToList();

        public Client AddClient(Client client)
        {
            var dbClient = context.Add(client);
            context.SaveChanges();

            return dbClient.Entity;
        }

        public Client GetClient(Guid id)
        {
            var client = context.Clients.Find(id);
            return client;
        }


        //Execute using 'FromSql' this will return query result 
        public IQueryable<Client> GetClientsWithFirstName(string FirstName)
            => context.Clients.FromSql($"GetClients '{FirstName}'");


        //Execute using 'ExecuteSqlCommand' this will execut CUD commands
        public void AddClient(string FirstName, string LastName)
            => context.Database.ExecuteSqlCommand($"CreateClient {FirstName}, {LastName}");

        public void Add10Clients()
        {
            var list = new List<Client>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Client() { FirstName = "first"+i, LastName = "last"+i });
            }
            context.AddRange(list);
            context.SaveChanges();
        }
    }
}

using ClientOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClientOrder.Data.Context
{
    public class ClientOrderContext : DbContext
    {
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        //public DbSet<ClientAddress> ClientAddresses { get; set; }
        
        //public DbSet<OrderDetails> OrderDetails { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Product> Products { get; set; }

        public ClientOrderContext(DbContextOptions<ClientOrderContext> options)
            :base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientAddress>()
                .HasKey(ca => new { ca.ClientId, ca.AddressId });
            modelBuilder.Entity<Address>()
                        .Property(a => a.FullAddress)
                        .IsRequired();
        }
    }
}

using System.Linq;
using ClientOrder.Data.Context;
using ClientOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ClientOrderTests
    {
       private  DbContextOptions<ClientOrderContext> _options;
        public ClientOrderTests()
        {
            _options = new DbContextOptionsBuilder<ClientOrderContext>()
                 .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                 .Options;
        }

        [TestMethod]
        public void CanAddAndUpdateSomeData()
        {
            var client = new Client { LastName = "Julie", FirstName = "Julie" };
            using (var context = new ClientOrderContext(_options))
            {
                context.Add(client);
                context.SaveChanges();
            }
            client.FirstName += "t";
            using (var context = new ClientOrderContext(_options))
            {
                context.Clients.Update(client);
                context.SaveChanges();
            }
            using (var context = new ClientOrderContext(_options))
            {
                Assert.AreEqual("Juliet", context.Clients.FirstOrDefault().FirstName);
            }
        }
    }
}

//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Console;

//namespace ClientOrder.Data.Context
//{
//    public class ClientOrderContextFactory : IDesignTimeDbContextFactory<ClientOrderContext>
//    {
//        private static ILoggerFactory loggerFactory
//            = new LoggerFactory(new[]
//            {
//                new ConsoleLoggerProvider((category, level)
//                    => category == DbLoggerCategory.Database.Command.Name
//                       && level == LogLevel.Information, true)
//            });

//        public ClientOrderContextFactory(ILoggerProvider loggerProvider = null)
//        {
//            if (loggerProvider != null)
//            {
//                loggerFactory = new LoggerFactory(new[] { loggerProvider });
//            }
//        }

//        public ClientOrderContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ClientOrderContext>()
//                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ClientOrderData; Trusted_Connection = True; ")
//                .UseLoggerFactory(loggerFactory);
//            var context = new ClientOrderContext(optionsBuilder.Options);
           
//            return context;
//        }
//    }
//}

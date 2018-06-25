//using ClientOrder.Domain.Entities;
//using ClientOrder.Data.Context;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClientOrder.App
//{
//    public class OrderDetailsAddModel
//    {
//        ClientOrderContext context = new ClientOrderContextFactory().CreateDbContext(args: new string[1]);

//        public OrderDetails Add(string details, Order order)
//        {
//            var orderDetails = new OrderDetails() { Details = details, OrderId = order.OrderId, Order = order };
//            var savedOrderDetails = context.OrderDetails.Add(orderDetails).Entity;
//            var result = context.SaveChanges();

//            return savedOrderDetails;
//        }
//    }
//}

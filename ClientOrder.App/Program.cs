//using ClientOrder.Domain.Entities;
//using ClientOrder.Data.Context;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;

//namespace ClientOrder.App
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            OrderDetailsAddModel orderDetailsAdd = new OrderDetailsAddModel();
//            var order = AddOrder();

//            var od = orderDetailsAdd.Add("details", order);
//        }



//            public static Order AddOrder()
//        {
//            ClientOrderContext context = new ClientOrderContextFactory().CreateDbContext(args: new string[0]);


//            var product = new Product() { Name = "Prod1", Price = 1 };
//            var savedProduct = context.Products.Add(product).Entity;

//            var orderDetails = new OrderDetails() { Details = "details" };
//            var savedOrderDetails = context.OrderDetails.Add(orderDetails).Entity;



//            Order order = new Order() { Name = "Order1", OrderId = new Guid(), Products = new List<Product>() { savedProduct }, OrderDetails = savedOrderDetails };
//            var savedOrder = context.Orders.Add(order).Entity;

//            context.SaveChanges();

//            return savedOrder;
//        }
//    }
//}

using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Controllers
{
    public class OrderController
    {
        public Order CreateOrder(ContosoPizzaContext context, int CustomerId)
        {
            var customer = context.Costumers.SingleOrDefault(c => c.Id == CustomerId);
            var order = new Order()
            {
                OrderPlaced = DateTime.Now,
                CustomerId = CustomerId,
                Customer = customer,
                OrderDetails = new List<OrderDetail>() { }
            };
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
        public Order GetOrder(ContosoPizzaContext context, int Id)
        {
            var order = context.Orders.SingleOrDefault(o => o.Id == Id);
            return order;
        }
        public Order UpdateOrder(ContosoPizzaContext context, int Id, List<OrderDetail> orderDetails)
        {
            var order = context.Orders.SingleOrDefault(order => order.Id == Id);
            order.OrderFulfilled = DateTime.Now;
            order.OrderDetails = orderDetails;
            context.SaveChanges();
            return order;
        }
        public Order DeleteOrder(ContosoPizzaContext context, int Id)
        {
            var order = context.Orders.SingleOrDefault(o => o.Id == Id);
            context.Orders.Remove(order);
            context.SaveChanges();
            return order;
        }
    }
}

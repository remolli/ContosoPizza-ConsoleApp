using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Controllers
{
    public class OrderDetailsController
    {
        public OrderDetail CreateOrderDetail(ContosoPizzaContext context, int OrderId, int productId, int quantity)
        {
            var order = context.Orders.SingleOrDefault(o => o.Id == OrderId);
            if (order == null) { return null; }

            var product = context.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null) { return null; }

            var orderDetail = new OrderDetail
            {
                Order = order,
                ProductId = productId,
                Product = product,
                Quantity = quantity
            };

            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();

            return orderDetail;
        }
        public OrderDetail GetOrderDetail(ContosoPizzaContext context, int orderDetailId)
        {
            var orderDetail = context.OrderDetails.SingleOrDefault(od => od.Id == orderDetailId);
            return orderDetail;
        }
        public List<OrderDetail> GetOrderDetails(ContosoPizzaContext context, int OrderId)
        {
            var orderDetails = context.OrderDetails.Where(od => od.Order.Id == OrderId);
            return orderDetails.ToList();
        }
        public OrderDetail UpdateOrderDetail(ContosoPizzaContext context, int orderDetailId, int productId, int quantity)
        {
            var orderDetail = context.OrderDetails.SingleOrDefault(od => od.Id == orderDetailId);
            var product = context.Products.SingleOrDefault(p => p.Id == productId);

            orderDetail.ProductId = productId;
            orderDetail.Product = product;
            orderDetail.Quantity = quantity;

            context.SaveChanges();
            return orderDetail;
        }
        public OrderDetail DeleteOrderDetail(ContosoPizzaContext context, int orderDetailId)
        {
            var orderDetail = context.OrderDetails.SingleOrDefault(od => od.Id == orderDetailId);
            context.OrderDetails.Remove(orderDetail);
            context.SaveChanges();
            return orderDetail;
        }
    }
}

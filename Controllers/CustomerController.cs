using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Controllers
{
    public class CustomerController
    {
        public Customer CreateCustomer(ContosoPizzaContext context, string FirstName, string LastName)
        {
            var customer = new Customer()
            {
                FirstName = FirstName,
                LastName = LastName,
                Orders = new List<Order>() { }
            };
            context.Costumers.Add(customer);
            context.SaveChanges();
            return customer;
        }
        public Customer UpdateCustomer(ContosoPizzaContext context, int Id, string newFirstName, string newLastName)
        {
            var customer = context.Costumers.SingleOrDefault(c => c.Id == Id);
            if (customer == null) { return customer; }
            customer.FirstName = newFirstName;
            customer.LastName = newLastName;
            context.SaveChanges();
            return customer;
        }
        public Customer GetCustomer(ContosoPizzaContext context, int Id)
        {
            var customer = context.Costumers.SingleOrDefault(c => c.Id == Id);
            return customer;
        }
        public Customer DeleteCustomer(ContosoPizzaContext context, int Id)
        {
            var customer = context.Costumers.SingleOrDefault(c => c.Id == Id);
            context.Costumers.Remove(customer);
            return customer;
        }
    }
}

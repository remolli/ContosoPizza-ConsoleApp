using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Controllers
{
    public class ProductController
    {
        public Product CreateProduct(ContosoPizzaContext context, string name, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Price = price
            };
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }
        public Product GetProduct(ContosoPizzaContext context, int Id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == Id);
            return product;
        }
        public List<Product> GetProducts(ContosoPizzaContext context)
        {
            var products = context.Products;
            return products.ToList();
        }
        public Product UpdateProduct(ContosoPizzaContext context, int Id, string name)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == Id);
            product.Name = name;
            context.SaveChanges();
            return product;
        }
        public Product UpdateProduct(ContosoPizzaContext context, int Id, decimal price)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == Id);
            product.Price = price;
            context.SaveChanges();
            return product;
        }
        public Product UpdateProduct(ContosoPizzaContext context, int Id, string name, decimal price)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == Id);
            product.Name = name;
            product.Price = price;
            context.SaveChanges();
            return product;
        }
        public Product DeleteProduct(ContosoPizzaContext context, int Id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == Id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
    }
}

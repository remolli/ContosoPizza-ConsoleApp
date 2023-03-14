using LearningEntityFrameworkCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningEntityFrameworkCore.Controllers;
using System.Diagnostics;
using LearningEntityFrameworkCore.Models;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LearningEntityFrameworkCore.Views.Dev
{
    public class ProductView
    {
        ProductController productController = new ProductController();
        public void TelaCreateProduct(ContosoPizzaContext context)
        {
            Console.Clear();
            Outros.YellowMessage("--- Criação de Produto ---");
            Console.WriteLine();
            Console.Write("Nome do Produto: ");
            string name = Console.ReadLine();
            Console.Write("Preço do Produto: ");
            try
            {
                var price = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();
                var product = productController.CreateProduct(context, name, price);
                if (name != null && price != null)
                {
                    if (product != null)
                    {
                        Outros.GreenText();
                        Console.WriteLine($"Produto '{product.Name}' Criado!");
                        Console.ResetColor();
                    }
                    else { Outros.RedMessage("Erro na criação do Produto."); }
                }
                else { Outros.RedMessage("Dados inválidos."); }
            }
            catch { Outros.RedMessage("Valor Inválido!"); }
            finally { Outros.PressAnyButton(); }
        }
        public void TelaUpdateProduct(ContosoPizzaContext context)
        {
            Console.Clear();
            Outros.YellowMessage("--- Atualização de Produto ---");
            Console.WriteLine();
            Console.Write("Id do Produto: ");
            try
            {
                var id = Convert.ToInt32(Console.ReadLine());
                var product = context.Products.SingleOrDefault(p => p.Id == id);
                if (product != null)
                {
                    Outros.GreenMessage($"Produto '{product.Name}' com preço '{product.Price}'");

                    Console.WriteLine("Deseja atualizar o 'Nome', 'Preco' ou 'Tudo'?");
                    var escolha = Console.ReadLine().ToLower().Replace(" ", "");

                    if (escolha == "nome")
                    {
                        Console.Write("Nome do Produto: ");
                        var name = Console.ReadLine();
                        if (name != null)
                        {
                            if (product != null)
                            {
                                var productModificado = productController.UpdateProduct(context, id, name);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Produto '{product.Name}' com Preço '{product.Price}' Atualizado!");
                                Console.ResetColor();
                            }
                            else { Outros.RedMessage("Erro na atualização do Produto!"); }
                        }
                        else { Outros.RedMessage("Dados inválidos."); }
                    }
                    else if (escolha == "preco")
                    {
                        Console.Write("Preço do Produto: ");
                        var price = Convert.ToDecimal(Console.ReadLine());
                        if (price != null)
                        {
                            if (product != null)
                            {
                                var productModificado = productController.UpdateProduct(context, id, price);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Produto {product.Name} atualizado com Preço {product.Price}");
                                Console.ResetColor();
                            }
                            else { Outros.RedMessage("Erro na atualização do Produto!"); }
                        }
                        else { Outros.RedMessage("Dados inválidos."); }
                    }
                    else if (escolha == "tudo")
                    {
                        Console.Write("Nome do Produto: ");
                        var name = Console.ReadLine();
                        Console.Write("Preço do Produto: ");
                        var price = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine();

                        if (name != null && price != null && id != null)
                        {
                            var productModificado = productController.UpdateProduct(context, id, name, price);
                            if (productModificado != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Produto {product.Name} atualizado com Preço {product.Price}");
                                Console.ResetColor();
                            }
                            else { Outros.RedMessage("Erro na atualização do Produto!"); }
                        }
                        else { Outros.RedMessage("Dados inválidos."); }
                    }
                    else { Outros.RedMessage("Dados inválidos."); }
                }
                else { Outros.RedMessage("Produto não encontrado."); }
            }
            catch { Outros.RedMessage("Valor Inválido."); }
            finally { Outros.PressAnyButton(); }

        }
        public void TelaDeleteProduct(ContosoPizzaContext context)
        {
            Console.Clear();
            Outros.YellowMessage("--- Deleção de Produto ---");
            Console.WriteLine();
            Console.Write("Id do Produto: ");
            try
            {
                var id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (id != null)
                {
                    var product = productController.GetProduct(context, id);
                    Outros.RedMessage($"Deseja deletar o Produto '{product.Name}' com preço '{product.Price}'?");
                    Console.WriteLine();
                    Outros.YellowMessage($"Escreva: 'Sim' ou 'Nao'");
                    var escolha = Console.ReadLine().ToLower().Replace(" ", "");
                    if (escolha == "sim")
                    {
                        productController.DeleteProduct(context, id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Produto '{product.Name}' com preço '{product.Price}' Deletado!");
                        Console.ResetColor();
                    }
                    else { Outros.RedMessage("Erro na deleção do Produto."); }
                }
                else { Outros.RedMessage("Dados inválidos."); }
            }
            catch { Outros.RedMessage("Valor Inválido."); }
            finally { Outros.PressAnyButton(); }
        }
        public void TelaGetProducts(ContosoPizzaContext context)
        {
            Console.Clear();
            var products = context.Products;
            Outros.YellowMessage("--- Todos Produtos ---");
            if (products != null)
            {
                foreach (var p in products)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Id:    {p.Id}");
                    Console.WriteLine($"Name:  {p.Name}");
                    Console.WriteLine($"Price: {p.Price}");
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 20));
                }
            }
            else { Outros.RedMessage("Não existem Produtos."); }
            Outros.PressAnyButton();
        }
        public void TelaGetProduct(ContosoPizzaContext context)
        {
            Console.Clear();
            Outros.YellowMessage("--- Ler Produto ---");
            Console.WriteLine();
            Console.Write("Id do Produto: ");
            try
            {
                var Id = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

                var product = context.Products.SingleOrDefault(p => p.Id == Id);
                if (product != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Id:    {product.Id}");
                    Console.WriteLine($"Name:  {product.Name}");
                    Console.WriteLine($"Price: {product.Price}");
                    Console.ResetColor();
                }
                else { Outros.RedMessage("Produto não encontrado."); }
            }
            catch { Outros.RedMessage("Valor Inválido."); }
            finally { Outros.PressAnyButton(); }
        }
    }
}

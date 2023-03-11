using LearningEntityFrameworkCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views
{
    public static class DevEnvironment
    {
        public static void Product(ContosoPizzaContext context)
        {
            var productView = new ProductView();

            string bemvindo = """
             | > Bem-vindo(a) ao ContosoPizza! < |

             """;
            string devProduto = """
             // --- Dev Environment ---
             // Tela de Manipulação de Produto

             """;
            string escreva = """
             Escreva o número ou a palavra do que deseja:
    
             """;
            string opcoes = """
                 1- 'Criar'
                 2- 'Ler Um'
                 3- 'Ler Todos'
                 4- 'Modificar'
                 5- 'Deletar'

                 'Sair' - Fechar aplicação

             """;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(bemvindo);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(devProduto);
                Console.ResetColor();
                Console.WriteLine(escreva);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(opcoes);
                Console.ResetColor();

                var escolha = Console.ReadLine();

                if (escolha == "1" || escolha.ToLower().Replace(" ", "") == "criar")
                {
                    productView.TelaCreateProduct(context);
                }
                else if (escolha == "2" || escolha.ToLower().Replace(" ", "") == "lerum")
                {
                    productView.TelaGetProduct(context);
                }
                else if (escolha == "3" || escolha.ToLower().Replace(" ", "") == "lertodos")
                {
                    productView.TelaGetProducts(context);
                }
                else if (escolha == "4" || escolha.ToLower().Replace(" ", "") == "modificar")
                {
                    productView.TelaUpdateProduct(context);
                }
                else if (escolha == "5" || escolha.ToLower().Replace(" ", "") == "deletar")
                {
                    productView.TelaDeleteProduct(context);
                }
                else if (escolha.ToLower() == "sair")
                {
                    Console.WriteLine("Fechando aplicação...");
                    Environment.Exit(0);
                }
                else
                {
                    Outros.EscrevaCorretamente();
                }
            }
        }
    }
}

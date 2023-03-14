using LearningEntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views.Menu
{
    public class VerificaDB
    {
        public static bool Run(ContosoPizzaContext context)
        {
            try { VerificaOuDeletaDB(context); return true; }
            catch { TentaCriarDB(context); return true; }
            finally { context.Database.CloseConnectionAsync().Wait(); }
        }
        public static void VerificaOuDeletaDB(ContosoPizzaContext context)
        {
            Console.WriteLine("Verificando se a Database existe...");
            context.Database.OpenConnectionAsync().Wait();
            Outros.GreenMessage("Database existente!");
            Outros.YellowMessage("Deseja acessá-la?");
            Outros.YellowMessage("1 - Sim");
            Console.WriteLine();
            Outros.RedMessage("Caso queira deletar o banco de dados");
            Outros.RedMessage("Escreva 'deletar'");

            var escolha = Console.ReadLine().Replace(" ", "").ToLower();
            if (escolha == "1")
            {
                Console.WriteLine("Carregando aplicação...");
                Thread.Sleep(3000);
                MenuViews.Menu(context);
            }
            else if (escolha == "deletar")
            {
                Console.WriteLine("Deletando database...");
                context.Database.EnsureDeleted();
                Outros.GreenMessage("Database Deletada!");
                Outros.BlueMessage("Até a proxima!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine();
                Outros.BlueMessage("Até a próxima!");
                Environment.Exit(0);
            }
        }
        public static void TentaCriarDB(ContosoPizzaContext context)
        {
            Outros.RedMessage("Database não encontrada, podemos criá-la?");
            Outros.YellowMessage("1 - Sim");
            Outros.YellowMessage("Caso Não, pressione qualquer botão");

            var escolha = Console.ReadKey();
            if (escolha.Key == ConsoleKey.D1)
            {
                Console.WriteLine();
                Console.WriteLine("Criando Database...");
                context.Database.EnsureCreated();
                Outros.GreenMessage("Database Criada.");
                Console.WriteLine("Carregando aplicação...");
                Thread.Sleep(3000);
                MenuViews.Menu(context);
            }
            else
            {
                Console.WriteLine();
                Outros.BlueMessage("Até a próxima!");
                Environment.Exit(0);
            }
        }
    }
}

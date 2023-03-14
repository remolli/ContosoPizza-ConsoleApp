using LearningEntityFrameworkCore.Models;
using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Views;
using Microsoft.EntityFrameworkCore;

using ContosoPizzaContext context = new ContosoPizzaContext();

try
{
    Outros.BlueMessage("  >  Menu  <  ");
    Console.WriteLine();
    Console.WriteLine("Verificando se a Database existe...");
    context.Database.OpenConnectionAsync().Wait();
    Outros.GreenMessage("Database existente!");
    Outros.YellowMessage("Deseja acessá-la?");
    Outros.YellowMessage("1 - Sim");
    Console.WriteLine();
    Outros.RedMessage("Caso queira deletar o banco de dados");
    Outros.RedMessage("Escreva 'deletar'");
    Console.WriteLine();

    var escolha = Console.ReadLine().Replace(" ", "").ToLower();
    if (escolha == "1")
    {
        Console.WriteLine("Carregando aplicação...");
        Thread.Sleep(3000);
        int? UserOrDev = MenuViews.Menu();
        if (UserOrDev == 1) { DevEnvironment.Product(context); }
        else if (UserOrDev == 2) { UserAuth.UserMenu(context); }
        else { Outros.RedMessage("Escreva apenas o número."); }
    }
    else if (escolha == "deletar")
    {
        Console.WriteLine("Deletando database...");
        context.Database.EnsureDeleted();
        Outros.GreenMessage("Database Deletada!");
        Outros.BlueMessage("Até a proxima!");
    }
    else
    {
        Console.WriteLine();
        Outros.BlueMessage("Até a próxima!");
    }
}
catch
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
        int? UserOrDev = MenuViews.Menu();
        if (UserOrDev == 1) { DevEnvironment.Product(context); }
        else if (UserOrDev == 2) { UserAuth.UserMenu(context); }
        else { Outros.RedMessage("Escreva apenas o número."); }
    }
    else
    {
        Console.WriteLine();
        Outros.BlueMessage("Até a próxima!");
    }
}
finally { context.Database.CloseConnectionAsync().Wait(); }
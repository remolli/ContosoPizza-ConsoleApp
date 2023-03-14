using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Views.Dev;
using LearningEntityFrameworkCore.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views.Menu
{
    public class MenuViews
    {
        public MenuViews()
        {

        }
        public static void Menu(ContosoPizzaContext context)
        {
            int? UserOrDev = DevOrUser();
            if (UserOrDev == 1) { DevEnvironment.Product(context); }
            else if (UserOrDev == 2) { UserAuth.UserMenu(context); }
            else { Outros.RedMessage("Escreva apenas o número."); }
        }
        public static int? DevOrUser()
        {
            Console.Clear();
            Outros.BemVindo();
            Console.WriteLine("Entrar como:");
            Console.WriteLine();
            Outros.YellowMessage("1 - Desenvolvedor");
            Outros.YellowMessage("2 - Usuário");
            Console.WriteLine();
            try
            {
                var escolha = Convert.ToInt16(Console.ReadLine());
                if (escolha == 1 || escolha == 2)
                {
                    return escolha;
                }
                else { return null; }
            }
            catch { Outros.RedMessage("Escreva o número da sua escolha."); return null; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views
{
    public class MenuViews
    {
        public MenuViews()
        {

        }
        public static int? Menu()
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
            finally { Outros.PressAnyButton(); }
        }

        public static int? UserMenu()
        {
            Outros.ContosoPizza();
            Console.WriteLine("1 - Logar");
            Console.WriteLine("2 - Cadastrar");
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
            finally { Outros.PressAnyButton(); }
        }

        public static int? DevMenu() 
        {
            return 0;
        }
    }
}

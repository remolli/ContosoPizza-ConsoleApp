using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views
{
    public class UserEnvironment
    {
        public UserEnvironment() { }
        public static int? UserMenu()
        {
            Outros.ContosoPizza();
            Console.WriteLine("1 - Logar");
            Console.WriteLine("2 - Cadastrar");
            try
            {
                var escolha = Convert.ToInt16(Console.ReadLine());
                if (escolha == 1)
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

using LearningEntityFrameworkCore.Data;
using LearningEntityFrameworkCore.Models;
using LearningEntityFrameworkCore.Views.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views.User
{
    public class UserAuth
    {
        public UserAuth() {  }
        public static void UserMenu(ContosoPizzaContext context)
        {
            Console.Clear();
            Outros.ContosoPizza();
            Console.WriteLine("1 - Logar");
            Console.WriteLine("2 - Cadastrar");
            try
            {
                var escolha = Convert.ToInt16(Console.ReadLine());
                if (escolha == 1)
                { Logar(context); }
                else if (escolha == 2)
                { Cadastrar(context); }
                else { Outros.RedMessage("Escreva apenas o número."); }
            }
            catch { Outros.RedMessage("Escreva o número da sua escolha."); }
            finally { Menu.MenuViews.Menu(context); }
        }

        public static void Cadastrar(ContosoPizzaContext context)
        {
            Console.Clear();
            var user = new Customer();
            Outros.BlueMessage("> Cadastro");
            Console.WriteLine();
            Outros.YellowMessage("* = Obrigatório");
            Outros.YellowMessage("Caso não queira responder as opcionais, apenas pressione Enter");
            Console.WriteLine();
            Console.Write("Primeiro nome: ");
            var firstName = Console.ReadLine();
            Console.Write("Sobrenome: ");
            var lastName = Console.ReadLine();
            Console.Write("Endereço: ");
            var address = Console.ReadLine();
            Console.Write("Telefone: ");
            var phone = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            user.FirstName = firstName;
            user.LastName = lastName;
            if (address != null) { user.Address = address; }
            if (phone != null) { user.Phone = phone; }
            if (email != null) { user.Email = email; }

            context.Add(user);

            Outros.GreenMessage($"Usuário '{user.FirstName} {user.LastName}' cadastrado");
            Outros.PressAnyButton();
            UserMenu(context);
        }
        public static void Logar(ContosoPizzaContext context)
        {
            Console.Clear();
            Outros.BlueMessage("> Login");
            Console.WriteLine();
            Console.Write("Primeiro nome: ");
            var firstName = Console.ReadLine();
            Console.Write("Sobrenome: ");
            var lastName = Console.ReadLine();

            var userFromDB = context.Costumers.FirstOrDefault(user => 
                (user.FirstName == firstName) && (user.LastName == lastName));

            if (userFromDB != null) 
            {
                Outros.GreenMessage("Login efetuado com sucesso!");
                SistemaViews.Inicio(); 
            }
            else { Outros.RedMessage("Nome ou Sobrenome incorretos."); }
        }
    }
}

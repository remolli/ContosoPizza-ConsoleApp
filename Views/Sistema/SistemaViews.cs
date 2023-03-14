using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views.Sistema
{
    public class SistemaViews
    {
        public SistemaViews() { }
        public static void Inicio()
        {
            Console.Clear();
            string opcoes = """
                1 - Realizar pedido
                2 - Visualizar pedidos
                3 - Exibir perfil
                4 - Editar perfil
                """;
            Outros.BemVindo();
            Console.WriteLine();
            Outros.YellowMessage(opcoes);
        }
    }
}

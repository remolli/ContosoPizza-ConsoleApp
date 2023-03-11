using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEntityFrameworkCore.Views
{
    public static class Outros
    {
        public static void EscrevaCorretamente()
        {
            Console.WriteLine();
            RedText();
            Console.WriteLine("Escreva corretamente!");
            Console.WriteLine();
            for (int i = 3; i > 0; i--)
            {
                Console.Write("  " + i + "   ");
                Thread.Sleep(1000);
            }
            ResetColor();
        }
        public static void PressAnyButton()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer botão...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void BemVindo() 
        {
            string bemvindo = """
                    | > Bem-Vindo ao ContosoPizza! < |

                    """;
            BlueMessage(bemvindo);
        }
        public static void ContosoPizza()
        {
            string contosopizza = """
                | > ContosoPizza < |

                """;
            BlueMessage(contosopizza);
        }
        public static void BlueText()
        {
            Console.ForegroundColor= ConsoleColor.Blue;
        }
        public static void YellowText() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void GreenText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void RedText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void BlueMessage(string message) 
        {
            BlueText();
            Console.WriteLine(message);
            ResetColor();
        }
        public static void YellowMessage(string message)
        {
            YellowText();
            Console.WriteLine(message);
            ResetColor();
        }
        public static void GreenMessage(string message)
        {
            GreenText();
            Console.WriteLine(message);
            ResetColor();
        }
        public static void RedMessage(string message)
        {
            RedText();
            Console.WriteLine(message);
            ResetColor();
        }
        public static void ResetColor()
        {
            Console.ResetColor();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UlElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Введите процент здоровья: ");
            int healthPercent = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите процент маны: ");
            int manaPercent = Convert.ToInt32(Console.ReadLine());

            int maxPercent = 100;

            healthPercent = Clamp(healthPercent, 0, maxPercent);
            manaPercent = Clamp(healthPercent, 0, maxPercent);

            int healthBar = 10;
            int manaBar = 10;

            DrawBar(healthPercent, healthBar, maxPercent, ConsoleColor.Green, 1);
            DrawBar(manaPercent, manaBar, maxPercent, ConsoleColor.Blue, 2);
        }

        static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }

            return value;
        }

        static void DrawBar(int percent, int barLength, int maxPercent, ConsoleColor color, int position)
        {
            char filledSymbol = '#';
            char openBracket = '[';
            char closeBracket = ']';
            char emptySymbol = '_';

            string bar;

            int filledLength = barLength * percent / maxPercent;
            int emptyLength = barLength - filledLength;

            ConsoleColor defaultColor = Console.BackgroundColor;

            bar = GetBar(filledLength, filledSymbol);

            Console.SetCursorPosition(0, position);
            Console.Write(openBracket);
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = GetBar(emptyLength, emptySymbol);

            Console.Write($"{bar}{closeBracket}\n");
        }

        static string GetBar(int length, char symbol)
        {
            string bar = string.Empty;

            for (int i = 0; i < length; i++)
            {
                bar += symbol;
            }

            return bar;
        }
    }
}

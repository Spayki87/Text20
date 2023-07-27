using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 4;
            int maxHealth = 10;

            DrawBar(health, maxHealth, ConsoleColor.Green);
        }
        static void DrawBar(int value, int maxValue, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += "#";
            }

            Console.SetCursorPosition(0, 0);
            Console.Write('[');
            Console.ForegroundColor = color;
            Console.Write(bar);
            Console.ForegroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += "_";
            }

            Console.Write(bar + ']');
            Console.WriteLine();
        }
    }
}

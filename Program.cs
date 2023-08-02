using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UlElement
{
    internal class Program
    {
        static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }

            if (value > max)
            {
                value = max;
            }

            return value;
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, int position)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string filledBar = "";
            char filledSymbol = '#';

            for (int i = 0; i < value; i++)
            {
                filledBar += filledSymbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(filledBar);
            Console.BackgroundColor = defaultColor;

            string emptyBar = "";
            char emptySymbol = '_';

            for (int i = value; i < maxValue; i++)
            {
                emptyBar += emptySymbol;
            }

            Console.Write($"{emptyBar}]\n");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Введите процент здоровья: ");
            int percentageHealth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите процент маны: ");
            int percentageMana = Convert.ToInt32(Console.ReadLine());

            int maxPercent = 100;

            percentageMana = Clamp(percentageMana, 0, maxPercent);
            percentageHealth = Clamp(percentageHealth, 0, maxPercent);

            int healthBar = 20;
            int currentHealth = healthBar * percentageHealth / maxPercent;
            int manaBar = 20;
            int currentMana = manaBar * percentageMana / maxPercent;

            DrawBar(currentHealth, healthBar, ConsoleColor.Green, 5);
            DrawBar(currentMana, manaBar, ConsoleColor.Blue, 6);
        }
    }
}

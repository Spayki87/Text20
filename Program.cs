using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float number = ReadNumber();

            Console.WriteLine($"Вы ввели число: {number}");
        }
        
        static float ReadNumber()
        {
            float number = 0;

            do
            {
                Console.WriteLine("Введите число: ");
            }
            while (float.TryParse(Console.ReadLine(), out number) == false);

            return number;
        }
    }
}

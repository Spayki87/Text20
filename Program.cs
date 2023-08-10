using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Кадровый_учет
{
    internal class Program
    {

        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandShowAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandSearchSurnames = "4";
            const string CommandExit = "5";

            bool exitProgram = true;

            string[] fullNames = new string[0];
            string[] posts = new string[0];
            string userInput;

            while (exitProgram == true)
            {
                Console.WriteLine($"{CommandAddDossier} - добавить досье.");
                Console.WriteLine($"{CommandShowAllDossiers} - вывести все досье.");
                Console.WriteLine($"{CommandDeleteDossier} - удалить досье.");
                Console.WriteLine($"{CommandSearchSurnames} - поиск по фамилии.");
                Console.WriteLine($"{CommandExit} - выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(ref fullNames, ref posts);
                        break;

                    case CommandShowAllDossiers:
                        ShowAllDossiers(fullNames, posts);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref fullNames, ref posts);
                        break;

                    case CommandSearchSurnames:
                        SearchSurnames(fullNames, posts);
                        break;

                    case CommandExit:
                        exitProgram = false;
                        Console.WriteLine("Вы вышли из программы.");
                        break;
                }
            }
        }

        static string[] IncreaseArray(string[] arrayInput, string input)
        {
            string[] tempArray = new string[arrayInput.Length + 1];

            for (int i = 0; i < arrayInput.Length; i++)
            {
                tempArray[i] = arrayInput[i];
            }

            tempArray[tempArray.Length - 1] = input;

            return tempArray;
        }

        static void AddDossier(ref string[] fullNames, ref string[] posts)
        {
            Console.WriteLine("Введите Фамилию Имя Отчество: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Введите должность");
            string post = Console.ReadLine();

            fullNames = IncreaseArray(fullNames, fullName);

            posts = IncreaseArray(posts, post);

        }

        static void ShowAllDossiers(string[] fullNames, string[] posts)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {fullNames[i]} - {posts[i]}");
            }
        }

        static string[] DecreasArray(string[] dossiers, int input)
        {
            string[] temp = new string[dossiers.Length - 1];

            for (int i = 0; i < input - 1; i++)
            {
                temp[i] += dossiers[i];
            }

            for (int i = input; i < dossiers.Length; i++)
            {
                temp[i - 1] = dossiers[i];
            }

            return temp;
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] posts)
        {
            int dossierNumber;

            Console.WriteLine("Выберите номер досье, которое хотите удалить: ");
            dossierNumber = int.Parse(Console.ReadLine());

            if (dossierNumber < 1 || dossierNumber > fullNames.Length)
            {
                Console.WriteLine("Не правильно введен номер досье.");
            }
            else
            {
                fullNames = DecreasArray(fullNames, dossierNumber);

                posts = DecreasArray(posts, dossierNumber);
            }
        }

        static void SearchSurnames(string[] fullNames, string[] posts)
        {
            string input;

            string[] tempFullName;

            char space = ' ';
            char delimiters = space;

            bool fullNameIsFound = false;

            Console.WriteLine("Введите Фамилию:");
            input = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++)
            {
                tempFullName = fullNames[i].Split(delimiters);

                if (input.ToLower() == tempFullName[0].ToLower())
                {
                    Console.WriteLine($"Ваше досье: {fullNames[i]} - {posts[i]}");
                    fullNameIsFound = true;
                }
            }
            if (fullNameIsFound == false)
            {
                Console.WriteLine("Такой Фамилии нет.");
            }
        }
    }
}
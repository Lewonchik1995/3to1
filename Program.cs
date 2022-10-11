using System.Globalization;
using System.Windows.Markup;

namespace _3to1
{
    internal class Program
    {
        static void Main()
        {
            bool endApp = true;
            do
            {
                Console.WriteLine("Выберите программу, которую хотите запустить:");
                Console.WriteLine("\t 1 - Игра 'Угадай число'");
                Console.WriteLine("\t 2 - Таблица умножения");
                Console.WriteLine("\t 3 - Вывод делителей числа");
                Console.WriteLine("\t 4 - Выход из программы");
                Console.WriteLine("Ввведите ваш выбор:");
                int operation = 0;
                while (!int.TryParse(Console.ReadLine(), out operation))
                {
                    Console.WriteLine("Ошибка ввода! Введите номер операции:");
                }
                switch (operation)
                {
                    case 1:
                        GameOut();
                        break;
                    case 2:
                        TableOut();
                        break;
                    case 3:
                        NumbersOut();
                        break;
                    case 4:
                        endApp = false;
                        break;
                    default:
                        Console.WriteLine("Такой операции нет!");
                        break;
                }
            } while (endApp);
        }

        static void GameOut()
        {
            Console.WriteLine("Программа 1 - Игра 'Угадай число'");
            Console.WriteLine("_________________________________");
            Random rnd = new Random();
            int value = rnd.Next(0, 100);
            int rndNum = Convert.ToInt32(value);
            Console.WriteLine("Загадано число от 0 до 100, введите ваше предположение:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))            {
                Console.WriteLine("Введите число");
            }
            do
            {
            if (number < rndNum)
            {
                Console.WriteLine("Надо больше");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Введите число");
                }
            }
            else
            {
                Console.WriteLine("Надо меньше");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                        Console.WriteLine("Введите число");
                }
            }
            }while (number != rndNum);
            Console.WriteLine("\n Вы угадали!!!\n");
        }

        static void TableOut()
        {
            Console.WriteLine("Программа 2 - Таблица умножения");
            Console.WriteLine("_______________________________\n");
            int[,] table = new int[10, 10];
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    table[i, j] = i * j;
                }
            }
            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        static void NumbersOut()
        {
            bool endApp = false;
            Console.WriteLine("Программа 3 - Вывод делителей числа");
            Console.WriteLine("___________________________________");
            do
            {
                Console.WriteLine("Введите число. Для выхода введите слово 'выйти':");
                string numberInput = Console.ReadLine();
                if (numberInput == "выйти")
                {
                    endApp = true;
                }   
                else
                {
                    int NotNumber = 0;
                    while (!int.TryParse(numberInput, out NotNumber))
                    {
                        Console.WriteLine("Ошибка ввода! Введите число:");
                        numberInput = Console.ReadLine();
                    }
                    int numToDiv = Convert.ToInt32(numberInput);
                    int del = numToDiv;
                    List<int> result = new List<int>() { };
                    while (del > 0)
                    {
                        if (numToDiv % del == 0)
                        {
                            result.Add(del);
                            del--;
                        }
                        else
                        {
                            del--;
                        }
                    }
                    result.Sort();
                    foreach (var number in result)
                    {
                        Console.Write(number + "\t");
                    }
                    Console.WriteLine("\n");
                }
            } while (!endApp);
            
        }
    }
}
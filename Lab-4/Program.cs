using LibraryForStringHandler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneRecords = new List<string>();
            string inputString;
            int n, i;
            

            bool isRun = true;
            while (isRun) 
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║             Выберите действие:         ║");
                Console.WriteLine("║            1 - Первая задача;          ║");
                Console.WriteLine("║            2 - Вторая задача;          ║");
                Console.WriteLine("║          0 - Выход из программы;       ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n");

                switch (ReadInt())
                {
                    case 1:
                        Console.WriteLine("Введите строку:");
                        inputString = ReadString();
                        Console.WriteLine(StringHandler.DividingTheString(inputString));
                        break;
                    

                    case 2:
                        // Пример входных данных (список строк с номерами, временем и длительностью звонков)
                        Console.WriteLine("Введите количество записей: ");
                        n = ReadInt();
                        Console.WriteLine("\nФормат записи: +XXXXXXXXXXXX 00:00 XXX(секунд)\n");
                        i = 0;
                        while (i < n)
                        {
                            phoneRecords.Add(Console.ReadLine());
                            i++;
                        }
                        
                        Console.WriteLine("\nВведите номер телефона, для которого ищем звонки после полуночи: \n");
                        // Номер, для которого ищем звонки после полуночи
                        string targetNumber = StringHandler.ValidateInput(Console.ReadLine());
                        Console.WriteLine();

                        StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);

                        Console.WriteLine(filteredRecords.ToString());
                        break;
                    
                    case 0:
                        isRun = false;
                        Console.WriteLine("Выход из программы...");
                        Console.ReadKey();
                        break;
                    
                    default: 
                        Console.WriteLine("Введите корректный номер пункта!");
                        break;
                }
            }

        }

        /// <summary>
        /// Метод для проверки вводимых целочисленных данных на корректность.
        /// </summary>
        /// <returns></returns>
        private static int ReadInt()
        {
            string numeral = Console.ReadLine();
            int value;
            while (!Int32.TryParse(numeral, out value))
            {
                Console.WriteLine("Введённые данные не подходят. Введите корректное значение: ");
                numeral = Console.ReadLine();
            }
            return value;
        }

        /// <summary>
        /// Метод для проверки вводимой строки на корректность.
        /// </summary>
        /// <returns></returns>
        private static string ReadString()
        {
            string value = Console.ReadLine();
            bool isRun = true;
            while (isRun)
            {
                if (value == "")
                {
                    Console.WriteLine("Строка пустая. Введите другю строку");
                    value = Console.ReadLine();
                }
                else isRun = false;
            }
            return value;
        }
    }
}

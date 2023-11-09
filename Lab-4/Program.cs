using LibraryForStringHandler;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string inputStringV1, inputString;
            int n;
            

            bool isRun = true;
            while (isRun) 
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║           Выберите действие:           ║");
                Console.WriteLine("║            1 - Первая задача;          ║");
                Console.WriteLine("║   2 - Ввод записей для второй задачи;  ║");
                Console.WriteLine("║   3 - Ввод записей для второй задачи;  ║");
                Console.WriteLine("║         0 - Выход из программы;        ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n");

                switch (ReadInt())
                {
                    case 1:
                        Console.WriteLine("Введите строку:");
                        inputStringV1 = Console.ReadLine();
                        Console.WriteLine(StringHandler.DividingTheString(inputStringV1));
                        break;
                    
                    case 2:

                        int i = 0;
                        Console.WriteLine("Введите количество записей: ");
                        n = ReadInt();
                        Console.WriteLine("Формат записи: +XXXXXXXXXXXXX 00:00 XXX(секунд)");
                        while (i < n)
                        {

                            inputString = StringHandler.ValidateInput(Console.ReadLine());
                            sb.Append(inputString);
                            sb.AppendLine("\n");
                            i++;
                        }
                        Console.WriteLine("Вы ввели следующие записи: ");
                        Console.WriteLine(sb);

                        break;
                    
                    case 3:
                        Console.WriteLine("Введите запись (Формат: +XXXXXXXXXXXXX 00:00 XXX(секунд)): ");
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
        public static int ReadInt()
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


    }
}

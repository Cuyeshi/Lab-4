using StringHandler;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            Console.WriteLine("Введите строку:");
            inputString = Console.ReadLine();
            Console.WriteLine(DividingTheString(inputString));
            Console.ReadKey();

            bool isRun = true;
            while (isRun) 
            {
                Console.WriteLine("\n");
                Console.WriteLine();
                Console.WriteLine();

                switch (ReadInt())
                {
                    case 1:
                        Console.WriteLine("Введите строку:");
                        inputString = Console.ReadLine();
                        Console.WriteLine(DividingTheString(inputString));
                        break;
                    
                    case 2:
                        break;
                    
                    case 3:
                        break;
                    
                    case 0:
                        break;
                    
                    default: 
                        Console.WriteLine("Введите корректный номер пункта!");
                        break;
                }
            }

        }

        static public string DividingTheString(string String)
        {
            bool isTrue;
            string resString = "";
            resString = resString + String[0];
            for (int i = 1; i < String.Length; i++)
            {
                isTrue = false;
                for (int j = 0; j < resString.Length; j++)
                {
                    if (resString[j] == String[i] || isTrue)
                    {
                        isTrue = true;
                        break;
                    }
                }
                if (!isTrue)
                {
                    resString = resString + String[i];
                }
            }
            return resString;
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

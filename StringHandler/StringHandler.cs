using System;
using System.Text.RegularExpressions;

namespace LibraryForStringHandler
{
    public class StringHandler
    {

        /// <summary>
        /// Метод для проверки вводимых строковых данных на корректность.
        /// </summary>
        /// <returns></returns>
        public static string ValidateInput(string chekingString)
        {
            //string pattern = @"^\+\d+ [0-23]{2}:[0-5]{1}[0-9]{1} \d+$"; // Формат: +XXXXXXXXXXXXX 00:00 XXX
            string pattern = @"^\+\d+ ?0[0-9]|1[0-9]|2[0-3]:?[0-5][0-9] \d+$";

            while (!Regex.IsMatch(chekingString, pattern))
            {
                Console.WriteLine("\nНекорректный ввод!");
                chekingString = Console.ReadLine();
            }
            return chekingString;
        }

        public static string DividingTheString(string String)
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
    }
}


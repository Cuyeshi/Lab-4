using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LibraryForStringHandler
{
    /// <summary>
    /// Класс для обработки строковых переменных.
    /// </summary>
    public class StringHandler
    {
        /// <summary>
        /// Метод для проверки вводимых строковых данных на корректность.
        /// </summary>
        /// <returns></returns>
        public static string ValidateInput(string chekingString)
        {
            string pattern = @"^\+375\d{9}$";

            while (!Regex.IsMatch(chekingString, pattern))
            {
                Console.WriteLine("\nНекорректный ввод!");
                chekingString = Console.ReadLine();
            }
            return chekingString;
        }

        /// <summary>
        /// Метод для нахождения "уникальных" символов и записи их в новую строку.
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        public static string DividingTheString(string String)
        {
            if (String == "")
                String = " ";
            bool isTrue;
            string resString = "";
            resString += String[0];
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
        /// Метод для создания строки с записями звонков на указанный номер после полуночи.
        /// </summary>
        /// <param name="phoneRecords"></param>
        /// <param name="targetNumber"></param>
        /// <returns></returns>
        public static StringBuilder GetCallsAfterMidnight(List<string> phoneRecords, string targetNumber)
        {
            StringBuilder result = new StringBuilder();
            int k = 0;

            foreach (string record in phoneRecords)
            {
                string[] parts = record.Split(' ');

                if (parts.Length != 3)
                {
                    Console.WriteLine($"Некорректный ввод записи: {k + 1}\n");
                    phoneRecords.RemoveAt(k);
                    break;
                }
                else
                {
                    string phoneNumber = parts[0];
                    string callTime = parts[1];
                    string callDuration = parts[2];

                    // Проверка формата времени (часы и минуты)
                    Regex timeRegex = new Regex(@"^0[0-9]|1[0-9]|2[0-3]:?[0-5][0-9]$");
                    if (!timeRegex.IsMatch(callTime))
                    {
                        Console.WriteLine($"Несоответствующий формат времени для записи: {k + 1}\n");
                        phoneRecords.RemoveAt(k);
                        break;
                    }
                    else
                    {
                        // Разделение времени на часы и минуты
                        string[] timeParts = callTime.Split(':');
                        int hours = Convert.ToInt32(timeParts[0]);
                        int minutes = Convert.ToInt32(timeParts[1]);
                        
                        // Проверка корректности времени (не больше 24 часов в сутках и не больше 60 минут в часе)
                        if (hours >= 24 || minutes >= 60)
                        {
                            Console.WriteLine($"Несоответствующий формат времени для записи: {k + 1}\n");
                            phoneRecords.RemoveAt(k);
                            break;
                        }
                        else
                        {
                            // Проверка номера телефона и времени звонка
                            if (phoneNumber == targetNumber && hours >= 0 && hours < 6) // После полуночи (00:00 - 05:59)
                            {
                                result.AppendLine(record);
                            }
                        }
                    }
                }

                k++;
            }
            if (result.Length != 0)
                result.Remove(result.Length - 2, 2);

            return result;
        }

        
    }
}


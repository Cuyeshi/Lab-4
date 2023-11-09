
using System.Text.RegularExpressions;

namespace StringHandler
{
    public class StringHandler
    {


        public static bool ValidateInput(string input)
        {
            string pattern = @"^\+\d+ [0-23]{2}:[0-23]{2} \d+$"; // Формат: +XXXXXXXXXXXXX 00:00 XXX
            return Regex.IsMatch(input, pattern);
        }

        public string DividingTheString(string String)
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


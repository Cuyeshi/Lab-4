using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryForStringHandler;


namespace TestForStrings
{
    [TestClass]
    public class TestsForStrings
    {
        private static bool CompareStrings(string firstString, string secondString) 
        { 
            if (firstString == secondString)
                return true; 
            else 
                return false;
        }

        /// <summary>
        /// Тест, проверяющий работоспособность case 1 при вводе одного слова в строке.
        /// </summary>
        [TestMethod]
        public void OneWordTestCase1()
        {
            string inputString = "Русские";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "Руские";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        /// <summary>
        /// Тест, проверяющий работоспособность case 1 при вводе одного слова в строке.
        /// </summary>
        [TestMethod]
        public void FewWordsTestCase1()
        {
            string inputString = "Русские не сдаются!";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "Руские ндаютя!";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }
    }
}

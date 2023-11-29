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

        [TestMethod]
        public void ZeroWordsTestCase1()
        {
            string inputString = "";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = " ";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void NumbersStringTestCase1()
        {
            string inputString = "123456789";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "123456789";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void DifferentRegisterTestCase1()
        {
            string inputString = "aaaAAAbbbBBBcccCCCdddDDD";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "aAbBcCdD";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }
        
        [TestMethod]
        public void UpperRegisterTestCase1()
        {
            string inputString = "AAABBBCCCDDDEEEFFFGGG";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "ABCDEFG";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }
        
        [TestMethod]
        public void LowerRegisterTestCase1()
        {
            string inputString = "zzzxxxccc";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "zxc";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }
        
        [TestMethod]
        public void SpecialSymbolsTestCase1()
        {
            string inputString = "!*!*@&@&#^#^$%$%";
            string convertedString = StringHandler.DividingTheString(inputString);
            string validString = "!*@&#^$%";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }
    }
}

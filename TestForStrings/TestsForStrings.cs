using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryForStringHandler;
using System.Text;
using System.Collections.Generic;


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

        [TestMethod]
        public void OneRecordAfterMidNight()
        {
            List<string> phoneRecords = new List<string>
            {
                { "+375299855559 03:11 404" }
            };
            string targetNumber = "+375299855559";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "+375299855559 03:11 404";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void FourRecordAfterMidNight()
        {
            List<string> phoneRecords = new List<string>
            {
                "+1234567890123 00:30 150",
                "+9876543210987 23:45 120",
                "+1112223334445 12:58 90",
                "+1234567890123 01:30 100",
                "+4445556667778 23:15 80"
            };
            string targetNumber = "+1234567890123";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "+1234567890123 00:30 150\r\n+1234567890123 01:30 100";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void ErrorInOneRecordsTestCase2()
        {
            List<string> phoneRecords = new List<string>
            {
                "+4445556667778 24:15 80"
            };
            string targetNumber = "+4445556667778";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void ErrorInFourRecordsTestCase2()
        {
            List<string> phoneRecords = new List<string>
            {
                "+1234567890123 00:30 150",
                "+9876543210987 23:45 120",
                "+1112223334445 12:58 90",
                "+1234567890123 01:30 100",
                "+4445556667778 24:15 80"
            };
            string targetNumber = "+4445556667778";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void NoComplianceCallsAfterMidnight()
        {
            List<string> phoneRecords = new List<string>
            {
                "+1234567890123 00:30 150",
                "+9876543210987 23:45 120",
                "+1112223334445 12:58 90",
                "+1234567890123 01:30 100",
                "+4445556667778 20:15 80"
            };
            string targetNumber = "+375299855559";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }

        [TestMethod]
        public void AllComplianceCallsAfterMidnight()
        {
            List<string> phoneRecords = new List<string>
            {
                "+375299855559 00:30 150",
                "+375299855559 23:45 120",
                "+375299855559 12:58 90",
                "+375299855559 01:30 100",
                "+375299855559 04:20 490",
                "+375299855559 01:30 100",
                "+375299855559 00:15 580"
            };
            string targetNumber = "+375299855559";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "+375299855559 00:30 150\r\n+375299855559 01:30 100\r\n+375299855559 04:20 490\r\n+375299855559 01:30 100\r\n+375299855559 00:15 580";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }
        
        [TestMethod]
        public void VoidListCallsAfterMidnight()
        {
            List<string> phoneRecords = new List<string>();
            string targetNumber = "+375299855559";
            StringBuilder filteredRecords = StringHandler.GetCallsAfterMidnight(phoneRecords, targetNumber);
            string convertedString = filteredRecords.ToString();
            string validString = "";

            Assert.IsTrue(CompareStrings(convertedString, validString));
        }


    }
}

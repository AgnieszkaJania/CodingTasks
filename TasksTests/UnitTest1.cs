using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingTasks;
using System.Collections.Generic;

namespace TasksTests
{
    [TestClass]
    public class UnitTestsNumber
    {
        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(11)]
        [DataRow(13)]
        [DataRow(23)]
        [DataRow(29)]
        public void Check_IsPrime_IsPrime(int n)
        {
            bool result = Program.IsPrime(n);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(9)]
        [DataRow(16)]
        [DataRow(21)]
        [DataRow(22)]
        [DataRow(30)]
        public void Check_IsPrime_IsNotPrime(int n)
        {
            bool result = Program.IsPrime(n);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 6)]
        [DataRow(4, 24)]
        [DataRow(5, 120)]
        [DataRow(7, 5040)]
        [DataRow(10, 3628800)]
        public void Check_Number_Factorial(int n, int expectedFactorial)
        {
            int factorial = Program.CalculateFactorial(n);//to do check for exception
            Assert.AreEqual(expectedFactorial, factorial);
        }
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(3, 2)]
        [DataRow(4, 3)]
        [DataRow(5, 5)]
        [DataRow(7, 13)]
        [DataRow(9, 34)]
        [DataRow(10, 55)]
        [DataRow(12, 144)]
        [DataRow(16, 987)]
        [DataRow(18, 2584)]
        public void Check_Number_FibonacciSequence(int n, int expectedValue)
        {
            int val = Program.FibonacciSequence(n);//to do check for exception
            Assert.AreEqual(expectedValue, val);
        }
    }
    [TestClass]
    public class UnitTestsString
    {
        private static readonly IList<string> expectedSubstrings = new List<string>() { "zakaz", "zaka", "zak", "za", "z", "akaz", "aka", "ak", "a", "kaz", "ka", "k", "az", "a", "z" };
 
        [TestMethod]
        [DataRow("pragnienia", "aineingarp")]
        [DataRow("Agnieszka", "akzseingA")]
        [DataRow("zakaz", "zakaz")]
        public void Check_String_ReverseString(string str, string expectedRes)
        {
            string res = Program.ReverseString(str);
            Assert.AreEqual(expectedRes, res);
            Assert.AreEqual(expectedRes, res);
            Assert.AreEqual(expectedRes, res);

        }
        [TestMethod]
        [DataRow("zakaz")]
        public void Check_String_All_Possible_Substrings(string str)
        {
            IList<string> res = Program.FindAllSubstring(str);
            foreach(string subStr in res)
            {
                Assert.IsTrue(expectedSubstrings.Contains(subStr));
            }
            Assert.AreEqual(expectedSubstrings.Count, res.Count);
        }
        [TestMethod]
        [DataRow("zakaz")]
        [DataRow("civic")]
        [DataRow("madam")]
        [DataRow("radar")]
        public void Check_String_IsPalindrome_Is_Palindrome(string str)
        {
            bool res = Program.IsPalindrome(str);
            Assert.IsTrue(res);
        }
        [TestMethod]
        [DataRow("agnieszka")]
        [DataRow("pies")]
        [DataRow("drabina")]
        [DataRow("drzewo")]
        public void Check_String_IsPalindrome_Is_Not_Palindrome(string str)
        {
            bool res = Program.IsPalindrome(str);
            Assert.IsFalse(res);
        }
        [TestMethod]
        [DataRow(")aga<>lubi(psy)")]
        [DataRow("aga lubi <(psy)>]")]
        [DataRow("aga lubi (psy)<")]
        [DataRow("aga lubi (psy)) i <koty>")]
        [DataRow("aga lubi [psy] i <<koty> i lubi te¿ {chomiki}")]
        [DataRow("aga lubi [[psy]] i <<koty> <i lubi te¿> {chomiki}")]
        [DataRow("aga lubi ((<psy")]
        [DataRow("aga lubi psy i <koty")]
        public void Check_Brackets_Correctness_Not_Correct(string inputStr)
        {
            bool result = Program.CheckIfBracketsCorrectlyPlaced(inputStr);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [DataRow("(<aga>)")]
        [DataRow("({[]})")]
        [DataRow("aga lubi [{psy}] i koty")]
        [DataRow("aga lubi <(psy)>")]
        [DataRow("aga lubi ([psy]) i bardzo lubi te¿ <<<((koty))>>>")]
        [DataRow("aga lubi <(chomiki)> ale {{[pajakow]}} nie lubi")]
        [DataRow("aga <{(lubi) koty i {{psy} tez lubi} ale os (<<<nie> lubi>>) w ogole}>")]
        [DataRow("{}")]
        [DataRow("(d)")]
        public void Check_Brackets_Correctness_Correct(string inputStr)
        {
            bool result = Program.CheckIfBracketsCorrectlyPlaced(inputStr);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class UnitTestsClock
    {
        [TestMethod]
        [DataRow(10, 30, 135)]
        [DataRow(3, 15, 7.5)]
        [DataRow(12, 15, 82.5)]
        [DataRow(1, 40, 170)]
        [DataRow(12, 0, 0)]
        public void Check_Clock_Angle(int hrs, int mins, double expectedAngle)
        {
            double angle = Program.FindAngleInTime(hrs, mins);
            Assert.AreEqual(expectedAngle, angle);
        }
    }

}

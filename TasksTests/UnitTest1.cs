using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingTasks;
using System.Collections.Generic;
using System.Linq;

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
        private static IEnumerable<object[]> GiveExpectedSubstrings() => new[] {
            new[] { new Dictionary<string, IList<string>>(){ {"zakaz",
                new List<string>(){ "zakaz", "zaka", "zak", "za", "z", "akaz", "aka", "ak", "a", "kaz", "ka", "k", "az", "a", "z"} } } }
        };
        private static IEnumerable<object> ExpectedCountCharResults() => new[] {
            new[] { new Dictionary<string, IDictionary<char, int>>(){ { "ala ma kota i psa i inne zwierzaki oraz x-mana",
                    new Dictionary<char, int>() { { 'a', 9 }, { 'l', 1 }, { 'm', 2 }, { 'k', 2 }, { 'o', 2 }, { 't', 1 }, { 'i', 5 },
                    { 'p', 1 }, { 's', 1 }, { 'n', 3 }, { 'e', 2 }, { 'z', 3 }, { 'w', 1 }, { 'r', 2 }, { 'x', 1 }, { '-', 1 } } } } },
            new[] { new Dictionary<string, IDictionary<char, int>>(){ {"aga i gitara", new Dictionary<char, int>() { { 'a', 4 }, { 'g', 2 },
                    { 'i', 2}, { 't', 1}, { 'r', 1} } } } }
        };

        [TestMethod]
        [DataRow("pragnienia", "aineingarp")]
        [DataRow("Agnieszka", "akzseingA")]
        [DataRow("zakaz", "zakaz")]
        public void Check_String_ReverseString(string str, string expectedRes)
        {
            string res = Program.ReverseString(str);
            Assert.AreEqual(expectedRes, res);
        }

        [TestMethod]
        [DynamicData(nameof(GiveExpectedSubstrings), DynamicDataSourceType.Method)]
        public void Check_String_All_Possible_Substrings(IDictionary<string, IList<string>> expectedSubstrings)
        {
            string word = expectedSubstrings.Keys.First();
            IList<string> res = Program.FindAllSubstring(word);
            Assert.IsTrue(CollectionHelper.AreListsEqual(res, expectedSubstrings[word]));
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
        
        [TestMethod]
        [DynamicData(nameof(ExpectedCountCharResults), DynamicDataSourceType.Method)]
        public void Check_Count_Characters_In_Text(IDictionary<string, IDictionary<char, int>> expectedCount)
        {
            string word = expectedCount.Keys.First();
            IDictionary<char, int> result = Program.CountCharactersInText(word);
            Assert.IsTrue(CollectionHelper.AreDictionariesEqual(result, expectedCount[word]));
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
    [TestClass]
    public class UnitTestsArray
    {
        private static IEnumerable<object[]> GiveTestArrays() => new[] {
                new[] { new [,] { { 1, 1, 1 }, { 0, 1, 0 }, { 2, 3, 0 }, { 6, 7, 9 } }, new [,] { { 1, 0, 2, 6 }, { 1, 1, 3, 7 }, { 1, 0, 0, 9 } } },
                new[] { new [,] { { 2, 1, 1, 5 }, { 0, 1, 0, 3 }, { 2, 3, 0, 6 } }, new [,] { { 2, 0, 2 }, { 1, 1, 3 }, {1, 0, 0}, {5, 3, 6 } } },
                new[] { new [,] { { 1, 3 }, { 5, 6 }, { 0, 0 } }, new [,] { { 1, 5, 0 }, {3, 6, 0 } } },
                new[] { new [,] { { 7, 9, 1, 6, 4, 5 }, { 0, 1, 0, 0, 9, 8 }, { 2, 3, 0, 8, 7, 1 } }, new[,] { { 7, 0, 2 }, { 9, 1, 3 }, { 1, 0, 0 }, { 6, 0, 8 }, { 4, 9, 7 }, { 5, 8, 1 } } },
                new[] { new [,] { { 7, 8, 1, 5, 5, 5, 1 } }, new[,] { { 7 }, { 8 }, { 1 }, { 5 }, { 5 }, { 5 }, { 1 } } },
                new[] { new [,] { { 2 }, { 5 }, { 3 }, { 0 } }, new[,] { {2, 5, 3, 0 } } },
                new[] { new [,] { { 2 } }, new [,] { { 2 } } }
        };

        [TestMethod]
        [DynamicData(nameof(GiveTestArrays), DynamicDataSourceType.Method)]
        public void Check_Transpose_Array(int[,] arr, int[,] expectedTransposedArr)
        {
            int[,] result = Program.TransposeArray(arr);
            CollectionAssert.AreEqual(expectedTransposedArr, result);
        }
    }
    [TestClass]
    public class UnitTestsCollectionHelper
    {
        private static IEnumerable<IDictionary<char, int>[]> GiveEqualDictionaries() => new[]
        {
            new[] { new Dictionary<char, int>() { { 'a', 2 }, {'w', 5 }, {'<', 3 }, {'c', 7}, {'e', 3 } }, new Dictionary<char, int>() { { 'a', 2 }, {'w', 5 }, {'<', 3 }, {'c', 7}, {'e', 3 } } },
            new[] { new Dictionary<char, int>() { { 'o', 4 }, {'x', 5 }, {'?', 1 }, {'t', 2}, {'{', 1 } }, new Dictionary<char, int>() { { 't', 2 }, {'{', 1 }, {'o', 4 }, {'?', 1}, {'x', 5 } } }
        };
        private static IEnumerable<IDictionary<char, int>[]> GiveNotEqualDictionaries() => new[]
        {
            new[] { new Dictionary<char, int>() { { 'a', 2 }, {'b', 5 }, {'q', 3 }, {'+', 1} }, new Dictionary<char, int>() { {'+', 1 }, {'q', 4 }, {'a', 2 }, {'b', 5 } } },
            new[] { new Dictionary<char, int>() { { 'o', 4 }, {'r', 5 }, {'!', 1 }, {'@', 2}, {'g', 1 } }, new Dictionary<char, int>() { {'r', 5 }, {'o', 4 }, {'@', 2 },  {'!', 1 } } },
            new[] { new Dictionary<char, int>() { { 'o', 4 }, {'r', 5 }, {'!', 1 }, {'@', 2}, {'g', 1 } }, new Dictionary<char, int>() { {'g', 1 }, {'@', 2 }, {'o', 4 }, { '!', 1 }, { 'r', 5 }, {'#', 1 } } },
        };
        private static IEnumerable<IList<string>[]> GiveEqualLists() => new[]
        {
            new[] {new List<string>() { "okno", "sofa", "rower", "pralka", "piec", "meble" }, new List<string>() { "sofa", "pralka", "meble", "rower", "okno", "piec"} },
            new[] {new List<string>() { "drzewo", "kwiat", "owoc"}, new List<string>() { "drzewo", "kwiat", "owoc"} }
        };
        private static IEnumerable<IList<string>[]> GiveNotEqualLists() => new[]
        {
            new[] {new List<string>() { "okno", "sofa", "rower", "pralka", "piec", "meble" }, new List<string>() { "meble", "sofa", "pralka", "kominek", "rower", "okno", "piec" } },
            new[] {new List<string>() { "sofa", "piec", "pralka", "meble", "rower", "okno" }, new List<string>() { "rower", "pralka", "piec", "meble" } },
            new[] {new List<string>() { "drzewo", "kwiat", "owoc"}, new List<string>() { "drzewo", "kwiat"} },
            new[] {new List<string>() { "drzewo", "kwiat", "owoc"}, new List<string>() { "drzewo", "kwiat", "owoc", "warzywo", "krzew"} }
        };

        [TestMethod]
        [DynamicData(nameof(GiveEqualDictionaries), DynamicDataSourceType.Method)]
        public void Check_AreDictionariesEqual_Are_Equal(IDictionary<char, int> firstDict, IDictionary<char, int> secondDict)
        {
            bool result = CollectionHelper.AreDictionariesEqual(firstDict, secondDict);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GiveNotEqualDictionaries), DynamicDataSourceType.Method)]
        public void Check_AreDictionariesEqual_Are_Not_Equal(IDictionary<char, int> firstDict, IDictionary<char, int> secondDict)
        {
            bool result = CollectionHelper.AreDictionariesEqual(firstDict, secondDict);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DynamicData(nameof(GiveEqualLists), DynamicDataSourceType.Method)]
        public void Check_AreListsEqual_Are_Equal(IList<string> firstList, IList<string> secondList)
        {
            bool result = CollectionHelper.AreListsEqual(firstList, secondList);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(GiveNotEqualLists), DynamicDataSourceType.Method)]
        public void Check_AreListsEqual_Are_Not_Equal(IList<string> firstList, IList<string> secondList)
        {
            bool result = CollectionHelper.AreListsEqual(firstList, secondList);
            Assert.IsFalse(result);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GuessPasswordGame.Play();
            //Clicker.Play();
            //FizzBuzz();
            FileProcessing.ProcesFileData(@"C:\Projekty_Visual_Studio\SourceFiles\Amounts.txt", 
                @"C:\Projekty_Visual_Studio\SourceFiles\AmountsSum.txt", (a, b) => a + b);
        }
        public static IList<string> FindAllSubstring(string txt)
        {
            // var subStr = new StringBuilder();
            IList<string> substrings = new List<string>();
            for (int i = 0; i < txt.Length; i++)
            {
                for (int j = i; j < txt.Length; j++)
                {
                    //subStr.AppendLine(txt.Substring(i, txt.Length - j));
                    substrings.Add(txt.Substring(i, txt.Length - j));
                }
            }
            // return subStr.ToString();
            return substrings;
        }
        private static void FindAllSubstringArrays(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                StringBuilder subString = new StringBuilder(str.Length - i);

                for (int j = i; j < str.Length; ++j)
                {
                    subString.Append(str[j]);
                    Console.Write(subString + "\n");
                }
            }
        }

        public static string ReverseString(string str)
        {
            char[] strArr = str.ToCharArray();
            Array.Reverse(strArr);
            return String.Join("", strArr);
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int[,] TransposeArray(int[,] arr)
        {
            int baseArrNumOfRows = arr.GetLength(0);
            int baseArrNumOfColumns = arr.GetLength(1);
            int[,] transposedArr = new int[baseArrNumOfColumns, baseArrNumOfRows];
            for(int r = 0; r < baseArrNumOfRows; r++)
            {
                for(int c = 0; c < baseArrNumOfColumns; c++)
                {
                    transposedArr[c, r] = arr[r, c];
                }
            }
            for (int r = 0; r < transposedArr.GetLength(0); r++)
            {
                for (int c = 0; c < transposedArr.GetLength(1); c++)
                {
                    Console.Write(transposedArr[r, c] + " ");
                }
                Console.WriteLine();
            }
            return transposedArr;

        }

        public static bool IsPalindrome(string str)
        {
            char[] reversed = str.ToCharArray();
            Array.Reverse(reversed);
            return str == String.Join("", reversed);
        }

        public static void FizzBuzz()
        {
            for(int i = 1; i <= 100; i++)
            {
               if(i % 15 == 0)
               {
                    Console.WriteLine("FizzBuzz");
                    continue;
               }
               if(i % 3 == 0)
               {
                    Console.WriteLine("Fizz");
                    continue;
               }
               if(i % 5 == 0)
               {
                    Console.WriteLine("Buzz");
                    continue;
               }
                Console.WriteLine(i);
                   
            }
        }
        public static double FindAngleInTime(int hrs, int mins)
        {
            double minuteDegrees = mins * 6;
            double hourDegrees = (hrs * 30) + (30 * (mins/60.0));
            double angle = Math.Abs(hourDegrees - minuteDegrees);
            if (angle > 180)
                angle = 360 - angle;
            return angle;
        }
        public static bool CheckIfBracketsCorrectlyPlaced(string input)
        {
            Stack<char> brackets = new Stack<char>();
            Dictionary<char, char> bracketsDict = new Dictionary<char, char>() { { '(',')' }, {'[',']' },
                { '{','}'}, {'<','>' } };

            foreach(char mark in input)
            {
                if(bracketsDict.ContainsKey(mark))
                {
                    brackets.Push(mark);
                    continue;
                }
                if (bracketsDict.ContainsValue(mark))
                {
                    if (brackets.Count == 0)
                    {
                        return false;
                    }
                    if (mark == bracketsDict[brackets.Peek()])
                    {
                        brackets.Pop();
                        continue;
                    }
                    return false;  
                }
            }
            return brackets.Count == 0;

        }
        public static int CalculateFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n can not be negative");
            if(n <= 1)
            {
                return 1;
            }
            return n * CalculateFactorial(n - 1);
        }
        public static int FibonacciSequence(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n can not be negative");
            if(n == 0)
            {
                return 0;
            }
            if(n == 1)
            {
                return 1;
            }
            return FibonacciSequence(n - 1) + FibonacciSequence(n - 2);
        }
        public static IDictionary<char, int> CountCharactersInText(string text)
        {
            IDictionary<char, int> dict = new Dictionary<char, int>();
            foreach(char character in text)
            {
                if(character == ' ')
                {
                    continue;
                }
                if (!dict.ContainsKey(character))
                {
                    dict.Add(character, 1);
                    continue;
                }
                else
                {
                    dict[character]++;
                }  
            }
            CollectionHelper.DisplayDictionary(dict);
            return dict;
        }
    }
    public class CollectionHelper
    {
        public static bool AreDictionariesEqual<T, U>(IDictionary<T, U> firstDict, IDictionary<T, U> secondDict)
        {
            if (firstDict.Count != secondDict.Count)
            {
                return false;
            }
            foreach (var kvp in firstDict)
            {
                if (!secondDict.ContainsKey(kvp.Key))
                {
                    return false;
                }
                if (!secondDict[kvp.Key].Equals(kvp.Value))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool AreListsEqual<T>(IList<T> firstList, IList<T> secondList)
        {
            return firstList.All(e => secondList.Contains(e)) && firstList.Count == secondList.Count;
        }
        public static void DisplayDictionary<T, U>(IDictionary<T, U> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"Key: {kvp.Key} Value: {kvp.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(FindAllSubstring("Agnieszka"));
            //FindAllSubstringArrays("Agnieszka");
            //Console.WriteLine(ReverseString("aineingarp"));
            //TransposeArray(new int[,] { { 1, 1, 1 }, { 0, 1, 0 }, { 2, 3, 0 }, { 6, 7, 9 } });
            //Console.WriteLine();
            //TransposeArray(new int[,] { { 2, 1, 1, 5 }, { 0, 1, 0, 3 }, { 2, 3, 0, 6 } });
            //Console.WriteLine();
            //TransposeArray(new int[,] { { 1, 3 }, { 5, 6 }, {0, 0} });
            //Console.WriteLine();
            //TransposeArray(new int[,] { { 7, 9, 1, 6, 4, 5 }, { 0, 1, 0, 0, 9, 8 }, { 2, 3, 0, 8, 7, 1 } });
            //Console.WriteLine();
            //TransposeArray(new int[,] { { 7, 8, 1, 5, 5, 5, 1} });
            //Console.WriteLine();
            //TransposeArray(new int[,] { { 2 },{ 5 },{ 3 },{ 0 } });
            //Console.WriteLine();
            //TransposeArray(new int[,] { { 2 }});
            //GuessPasswordGame.Play();
            //Clicker.Play();
            FizzBuzz();

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTasks
{
    public static class GuessPasswordGame
    {
        private readonly static string[] _words = new string[] { "agrafka", "rakieta", "pomidor", "traktor", 
            "warzywo", "cytryna"};
        private static int num;
        private static string word;
        private static char[] wordToGuess;
        private const char star = '*';

        public static void Play()
        {
            _initializeGame();
            _displayIntro();
            _move();

        }

        private static void _initializeGame()
        {
            var rnd = new Random();
            num = rnd.Next(0, _words.Length - 1);
            word = _words[num];
            wordToGuess = new char[word.Length];
            for(int i = 0; i < word.Length; i++)
            {
                wordToGuess[i] = star;
            }

        }
        private static void _displayIntro()
        {
            Console.WriteLine("=================================================================================");
            Console.WriteLine("=========== Welcome to guess Pasword Game, try to guess password! ===============");
            Console.WriteLine($"Password to guess: {String.Join("", wordToGuess)}");
            Console.WriteLine("=================================================================================");
        }
        private static void _move()
        {
            char letter;
            while (true)
            {
                Console.WriteLine("Podaj literę:");
                letter = Char.Parse(Console.ReadLine().Trim().ToLower());
                for(int i = 0; i < word.Length; i++)
                {
                    if(letter == word[i])
                    {
                        wordToGuess[i] = letter;
                    }
                }
                Console.WriteLine($"Password to guess: {String.Join("", wordToGuess)}");

                if (!Array.Exists(wordToGuess, el => el == star))
                {
                    Console.WriteLine("===================== BRAWO ODGADŁEŚ HASŁO!!! =========================");
                    break;
                }

            }
        }

    }
}

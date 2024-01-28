using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTasks
{
    public class Clicker
    {   
        private static TimeSpan minTime { get; set; }
        private static TimeSpan maxTime { get; set; }
        private static Stopwatch stopWatch;
        private static void _displayIntro()
        {
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("======== Welcome to Key Clicker Game, try to clicke keys as fast as possible! ===========");
            Console.WriteLine("======================== We will see how fast you can click keys! =======================");
        }
        private static void _initGame()
        {
            stopWatch = new Stopwatch();
            minTime = new TimeSpan(long.MaxValue);
            maxTime = new TimeSpan(0);

        }
        private static bool _isKeyEnter(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.Enter;
        }
        private static void _finishGame()
        {
            Console.WriteLine("============================== Game finished by the user! ===============================");
            Environment.Exit(0);

        }

        public static void Play()
        {
            _displayIntro();
            _initGame();
            Console.WriteLine("=============================== Click any key to begin! =================================");
            Console.WriteLine("============================ Click Enter key to exit game! ==============================");
            if (_isKeyEnter(Console.ReadKey()))
            {
                _finishGame();
            }

            while(true)
            {
                stopWatch.Reset();
                Console.WriteLine("Go");
                stopWatch.Start();
                var key = Console.ReadKey();
                stopWatch.Stop();

                if(_isKeyEnter(key))
                {
                    break;
                }

                if(minTime > stopWatch.Elapsed)

                {
                    minTime = stopWatch.Elapsed;
                }
                if(maxTime < stopWatch.Elapsed)
                {
                    maxTime = stopWatch.Elapsed;
                }

                Console.WriteLine("Minimalny czas:\t Runda:\t\t Maksymalny czas:\t");
                Console.WriteLine($" {minTime}\t {stopWatch.Elapsed}\t {maxTime}\t");
            }
            _finishGame();
        }
    }
}

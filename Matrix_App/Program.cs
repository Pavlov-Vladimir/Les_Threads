using System;
using System.Threading;

namespace test
{
    class Program
    {
        static object locker = new();
        static int[] colums = new int[Console.WindowWidth];
        static void Main(string[] args)
        {
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            Random rnd = new();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                if (i < 30)
                    Thread.Sleep(rnd.Next(50));
                Thread.Sleep(rnd.Next(50, 500));
                Thread drop = new Thread(RunDrop);
                drop.Start();
            }
        }

        private static void RunDrop()
        {
            Random rnd = new();
            //int xPos;
            int xPos = GetUnicColum(rnd);

            while (true)
            {
                Console.CursorVisible = false;
                int lenghtDrop = rnd.Next(5, 30);

                for (int y = 0; y < Console.WindowHeight + lenghtDrop; y++)
                {
                    lock (locker)
                    {
                        int yPos = y;
                        for (int i = 0; i < Console.WindowHeight + lenghtDrop + 1; i++)
                        {
                            if (yPos >= 0)
                            {
                                if (Console.WindowHeight - 3 - i < lenghtDrop)
                                    lenghtDrop--;
                                Console.SetCursorPosition(xPos, yPos--);
                                if (i < lenghtDrop)
                                {
                                    SetCharColor(i);
                                    Console.WriteLine(GetChar());
                                }
                                //if (i == lenghtDrop)
                                Console.WriteLine(' ');
                            }
                        }
                    }
                }
            }
        }

        private static int GetUnicColum(Random rnd)
        {
            int xPos;
            while (true)
            {
                xPos = rnd.Next(Console.WindowWidth);
                if (colums[xPos] == 0)
                {
                    colums[xPos] = xPos;
                    break;
                }
            }
            return xPos;
        }

        private static char GetChar()
        {
            Random rnd = new();
            return Convert.ToChar(rnd.Next(65, 125));
        }

        private static void SetCharColor(int charPositionInDrop)
        {
            if (charPositionInDrop == 0)
                Console.ForegroundColor = ConsoleColor.White;
            else if (charPositionInDrop == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}

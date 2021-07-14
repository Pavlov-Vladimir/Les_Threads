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
            Random rnd = new();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Thread.Sleep(rnd.Next(100, 1000));
                Thread drop = new Thread(RunDrop);
                drop.Start();
            }

            //RunDrop();



            Console.ReadKey();
        }

        private static void RunDrop()
        {
            Random rnd = new();
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

            while (true)
            {
                int lenghtDrop = rnd.Next(5, 25);

                //lock (locker)
                {
                    for (int y = 0; y < Console.WindowHeight + lenghtDrop; y++)
                    {
                        lock (locker)
                        {
                            int yPos = y;
                            for (int i = 0; i < Console.WindowHeight + lenghtDrop; i++)
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
                                    Console.WriteLine(' ');
                                }

                            }
                            //Thread.Sleep(rnd.Next(5, 50));
                            //Console.Clear(); 
                        }
                    }
                }
            }
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

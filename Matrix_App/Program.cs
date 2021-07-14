using System;
using System.Threading;

namespace Matrix_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();

            char[] str = new char[rnd.Next(5, 15)];

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Convert.ToChar(rnd.Next(65, 125));
            }

            //int xPosition = rnd.Next(80);
            for (int i = 0; i < str.Length; i++)
            {
                SetCharColor(i);


                //Console.Write(str[i]);
                //Thread.Sleep(50);
                //Console.SetCursorPosition(xPosition, i);
                //Console.Write(Convert.ToChar(rnd.Next(65, 125)));
                //Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.ResetColor();


            while (true)
            {
                int xPosition = rnd.Next(80);
                for (int i = 0; i < Console.WindowHeight; i++)
                {

                    for (int j = 0; j < str.Length; j++)
                    {
                        if (j <= i)
                        {
                            Console.SetCursorPosition(xPosition, i);
                            Console.Write(str[j]);
                            //Console.Clear();
                        }
                            Thread.Sleep(150);
                    }
                }
            }



            Console.ReadKey();
        }

        private static void SetCharColor(int i)
        {
            if (i == 0)
                Console.ForegroundColor = ConsoleColor.White;
            else if (i == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

    }
}

using System;
using System.Threading;

namespace Threads_App
{
    class Program
    {
        static int num = 0;
        static void Main(string[] args)
        {
            Thread thread = new(RecursiveTread) { Name = num++.ToString() };
            thread.Start();
        }

        static void RecursiveTread()
        {
            Console.WriteLine(new string(' ', num) + Thread.CurrentThread.Name);
            Thread.Sleep(500);

            Thread thread = new(RecursiveTread);
            thread.Name = num++.ToString();
            thread.Start();
        }
    }
}
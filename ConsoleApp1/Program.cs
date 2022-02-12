using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            for (int i = 100; i < 1000; i++)
            {
                if (result(i) != null)
                {
                    Console.WriteLine($"The answer is {i}");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("The is no answer...");
        }

        public static string result(int x)
        {
            var a = x % 10;
            var b = x / 100;
            var c = (x / 10) % 10;
            var s = 0;
            var k = 0;
            if (a % 2 > 0)
            {
                s = s + a;
            }
            else
            {
                k = k + 1;
            }

            if (b % 2 > 0)
            {
                s = s + b;
            }
            else
            {
                k = k + 1;
            }

            if (c % 2 > 0)
            {
                s = s + c;
            }
            else
            {
                k = k + 1;
            }

            if (k == 1 && s == 10)
                return "We have the answer!";
            return null;
        }
    }
}
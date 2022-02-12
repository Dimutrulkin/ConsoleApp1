using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            for (int i = 100; i > 0; i--)
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
            var s = 0;
            var p = 1;
            if (a % 2 == 0)
            {
                s = s + a;
            }
            else
            {
                p = p * 2;
            }

            if (b % 2 == 0)
            {
                s = s + b;
            }
            else
            {
                p = p * b;
            }
            
            if (s == 12 && p == 1)
                return "We have the answer!";
            return null;
        }
    }
}
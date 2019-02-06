using System;

namespace P01RhombusofStars
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintRow(n, i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                PrintRow(n, i);
            }
        }

        private static void PrintRow(int n, int i)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < i; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}


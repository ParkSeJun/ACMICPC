using System;

namespace _20200717_11653
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    n /= i;
                    Console.WriteLine(i);
                }
            }
        }
    }
}

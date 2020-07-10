using System;
using System.Collections.Generic;

namespace _20200710_9461
{
    class Program
    {
        static Dictionary<int, long> table = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Solve(n));
            }
        }

        static long Solve(int n)
        {
            if (n == -1 || n == 1)
                return 1;
            if (n <= 0)
                return 0;

            if (!table.ContainsKey(n))
            {
                table[n] = Solve(n - 1) + Solve(n - 5);
            }
            return table[n];
        }
    }
}

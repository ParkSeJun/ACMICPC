using System;
using System.Collections.Generic;

namespace _20200709_1904
{
    class Program
    {
        static Dictionary<int, int> table = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(Solve(a));
        }

        static int Solve(int n)
        {
            if (n < 0)
                return 0;
            if (n <= 1)
                return 1;

            if (!table.ContainsKey(n))
            {
                table[n] = (Solve(n - 1) + Solve(n - 2)) % 15746;
            }
            return table[n];
        }
    }
}

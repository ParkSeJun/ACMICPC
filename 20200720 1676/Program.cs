using System;
using System.Collections.Generic;

namespace _20200720_1676
{
    class Program
    {
        static Dictionary<int, int> div2 = new Dictionary<int, int>();
        static Dictionary<int, int> div5 = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Solve(n));
        }

        static int Solve(int n)
        {
            int div2 = 0;
            int div5 = 0;


            for (int i = 2; i <= n; i++)
            {
                div2 += Get2(i);
                div5 += Get5(i);
            }

            return Math.Min(div2, div5);
        }

        static int Get2(int n)
        {
            if (n < 2 || (n & 1) != 0)
                return 0;

            if (!div2.ContainsKey(n))
                div2[n] = 1 + Get2(n / 2);

            return div2[n];
        }

        static int Get5(int n)
        {
            if (n < 5 || n % 5 != 0)
                return 0;

            if (!div5.ContainsKey(n))
                div5[n] = 1 + Get5(n / 5);

            return div5[n];
        }
    }
}

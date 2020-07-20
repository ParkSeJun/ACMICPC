using System;
/*
25 12

2
*/
namespace _20200720_2004
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            int n = row[0];
            int k = row[1];

            // nCk = nPk / k! = n! / k! / (n-k)!

            int n2 = Get(n, 2);
            int n5 = Get(n, 5);
            int k2 = Get(k, 2);
            int k5 = Get(k, 5);
            int nk2 = Get(n - k, 2);
            int nk5 = Get(n - k, 5);

            n2 -= k2 + nk2;
            n5 -= k5 + nk5;
            int ret = Math.Max(0, Math.Min(n2, n5));

            Console.WriteLine(ret);
        }

        static int Get(int factorialN, int div)
        {
            int t = div;
            int count = 0;
            while (t <= factorialN)
            {
                count += factorialN / t;

                if (t > int.MaxValue / div)
                    break;

                t *= div;
            }
            return count;
        }
    }
}

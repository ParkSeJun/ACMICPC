using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _20200728_11401
{
    class Program
    {
        static Dictionary<int, int> permutationDic = new Dictionary<int, int>();
        static long p = 1000000007;

        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            long n = row[0];
            long k = row[1];

            if (k == n)
            {
                Console.WriteLine(1);
                return;
            }

            if (k > n / 2)
                k = n - k;

            if (k == 0)
            {
                Console.WriteLine(0);
                return;
            }


            long nf = 0, nkf = 0, kf = 0;
            long f = 1;
            for (long i = 1; i <= k; i++)
                f = (f * i) % p;
            kf = f;
            for (long i = k + 1; i <= n - k; i++)
                f = (f * i) % p;
            nkf = f;
            for (long i = n - k + 1; i <= n; i++)
                f = (f * i) % p;
            nf = f;


            long ret = (nf % p) * (GetPow2((kf * nkf) % p, p - 2) % p) % p;


            Console.WriteLine(ret);
        }
               
        static long GetPow1(long n, long pow)
        {
            if (pow == 0)
                return 1;

            long half = GetPow1(n, pow / 2);
            long square = half * half;
            if ((pow & 1) == 1)
                return square * n;
            return square;
        }

        static long GetPow2(long n, long pow)
        {
            long ret = 1;
            while (pow > 0)
            {
                if ((pow & 1) == 1)
                    ret = (ret * n) % p;
                n = (n * n) % p;
                pow /= 2;
            }
            return ret;
        }
    }
}

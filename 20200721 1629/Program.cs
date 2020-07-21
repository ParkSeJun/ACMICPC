using System;

namespace _20200721_1629
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            long a = row[0];
            long b = row[1];
            long c = row[2];

            Console.WriteLine(Solve(a,b,c));
        }

        static long Solve(long a, long b, long c)
        {
            if (b == 0)
                return 1;

            long half = Solve(a, b / 2, c);
            long ret = (half * half) % c;
            if ((b & 1) == 1)
                ret = (ret * a) % c;
            return ret;
        }
    }
}

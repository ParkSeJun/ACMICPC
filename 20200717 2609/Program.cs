using System;

namespace _20200717_2609
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll( Console.ReadLine().Split(' '), e => int.Parse(e));
            int gcd = GCD(row[0], row[1]);
            int lcm = LCM(row[0], row[1], gcd);
            Console.WriteLine(gcd);
            Console.WriteLine(lcm);
        }

        static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
        static int LCM(int a, int b, int gcd)
        {
            return a / gcd * b;
        }
    }
}

using System;
/*
4
12 3 8 4

4/1
3/2
3/1
*/

namespace _20200717_3036
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));

            for (int i = 1; i < count; i++)
            {
                int gcd = GCD(arr[0], arr[i]);
                Console.WriteLine($"{arr[0] / gcd}/{arr[i] / gcd}");
            }
        }

        static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
/*
25 12

2
*/
namespace _20200720_2004
{
    class Program
    {
        static List<int> arr2 = new List<int>();
        static List<int> arr5 = new List<int>();

        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            int n = row[0];
            int k = row[1];

            int t = 1;
            while (t <= int.MaxValue / 2)
            {
                arr2.Add(t);
                t *= 2;
            }
            arr2.Add(t);

            t = 1;
            while (t <= int.MaxValue / 5)
            {
                arr5.Add(t);
                t *= 5;
            }
            arr2.Add(t);

            var molecular = GetPermutation(n, k);
            var denominator = GetPermutation(k, k);
            var sum = new KeyValuePair<int, int>(molecular.Key - denominator.Key, molecular.Value - denominator.Value);
            var ret = Math.Max(0, Math.Min(sum.Key, sum.Value));
            Console.WriteLine(ret);
        }

        static KeyValuePair<int, int> GetPermutation(int n, int k)
        {
            int div2 = 0;
            int div5 = 0;
            for (int i = 0; i < k; i++)
            {
                div2 += Get2(n - i);
                div5 += Get5(n - i);
            }

            return new KeyValuePair<int, int>(div2, div5);
        }

        static int Get2(int n)
        {
            for (int i = arr2.Count - 1; i > 0; --i)
                if (n % arr2[i] == 0)
                    return i;
            return 0;
        }

        static int Get5(int n)
        {
            for (int i = arr5.Count - 1; i > 0; --i)
                if (n % arr5[i] == 0)
                    return i;
            return 0;
        }
    }
}

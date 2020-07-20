using System;
using System.Collections.Generic;
/*
5 2
10
*/
namespace _20200717_11051
{
    class Program
    {
        static Dictionary<KeyValuePair<int,int>, int> table = new Dictionary<KeyValuePair<int, int>, int>();

        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            int n = row[0];
            int k = row[1];
            Console.WriteLine(Solve(n, k));
        }

        static int Solve(int n, int k)
        {
            if (n == k || k == 0)
                return 1;

            var kvp = new KeyValuePair<int,int>(n, k);
            if(!table.ContainsKey(kvp))
                table[kvp] = (Solve(n - 1, k) + Solve(n - 1, k - 1)) % 10007;

            return table[kvp];
        }
    }
}

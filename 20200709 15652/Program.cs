using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200709_15652
{
    class Program
    {

        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
            int n = row[0];
            int m = row[1];

            Solve(n, m, new List<int>());
            Console.WriteLine(sb.ToString());
        }

        static void Solve(int n, int m, List<int> l)
        {
            if (l.Count >= m)
            {
                sb.AppendLine(string.Join(" ", l));
                return;
            }

            l = new List<int>(l);
            for (int i = 1; i <= n; i++)
            {
                if (l.Count > 0 && l[l.Count - 1] > i)
                    continue;

                l.Add(i);
                Solve(n, m, l);
                l.RemoveAt(l.Count - 1);
            }
        }
    }
}

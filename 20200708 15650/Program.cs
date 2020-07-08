using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200708_15650
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            var row = Console.ReadLine().Split(' ');
            n = int.Parse(row[0]);
            m = int.Parse(row[1]);
            Solve(n, m, new List<int>());
        }

        static void Solve(int n, int m, List<int> l)
        {
            l = new List<int>(l);
            if (l.Count == m)
            {
                Console.WriteLine(string.Join(" ", l));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (l.Count > 0 && l[l.Count - 1] >= i)
                    continue;
                l.Add(i);
                Solve(n, m, l);
                l.Remove(i);
            }
        }
    }
}

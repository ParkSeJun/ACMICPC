using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
3
6
34
38

    2
    4
*/

namespace _20200717_2981
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> l = new List<int>();
            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(Console.ReadLine());
                l.Add(n);
            }
            l.Sort();

            List<int> t = new List<int>();
            for (int i = 1; i < l.Count; i++)
            {
                int n = l[i] - l[i - 1];
                t.Add(n);
            }

            int gcd = GCD(t);
            var a = GetFactors(gcd);
            if (gcd > 1)
                a.Add(gcd);
            a.Sort();
            a = a.Distinct().ToList();
            Console.WriteLine(string.Join(" ", a));
        }

        static List<int> GetFactors(int n)
        {
            List<int> l = new List<int>();

            if (n <= 2)
                return l;

            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                {
                    l.Add(i);
                    l.Add(n / i);
                }

            return l;
        }

        static int GCD(List<int> l)
        {
            int a = l[0];
            for (int i = 1; i < l.Count; i++)
                a = GCD(a, l[i]);
            return a;
        }

        static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
    }
}

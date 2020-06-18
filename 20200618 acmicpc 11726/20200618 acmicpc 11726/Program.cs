using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200618_acmicpc_11726
{
    class Program 
    {
        static Dictionary<int, int> map = new Dictionary<int, int>(IntEqualityComparer.Default);

        static void Main(string[] args)
        {
            Console.WriteLine(Solve(1));
            Console.WriteLine(Solve(2));
            Console.WriteLine(Solve(3));
            Console.WriteLine(Solve(4));
        }

        public static int Solve(int n)
        {
            if (n < 0)
                return 0;
            if (n <= 1)
                return 1;

            if (map.ContainsKey(n))
                return map[n];

            return map[n] = Solve(n - 1) + Solve(n - 2);
        }
    }

    public class IntEqualityComparer : IEqualityComparer<int>
    {
        static volatile IntEqualityComparer defaultComparer;

        public static IntEqualityComparer Default
        {
            get
            {
                IntEqualityComparer comparer = defaultComparer;

                if (comparer == null)
                {
                    comparer = new IntEqualityComparer();
                    defaultComparer = comparer;
                }

                return comparer;
            }
        }

        bool IEqualityComparer<int>.Equals(int x, int y)
        {
            return x == y;
        }

        int IEqualityComparer<int>.GetHashCode(int obj)
        {
            return obj.GetHashCode();
        }
    }
}

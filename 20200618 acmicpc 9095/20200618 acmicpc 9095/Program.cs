using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200618_acmicpc_9095
{
    class Program
    {
        static Dictionary<int, int> map = new Dictionary<int, int>(IntEqualityComparer.Default);

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Trim());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(Console.ReadLine());
                sb.AppendLine(Solve(n).ToString());
            }
                Console.WriteLine(sb.ToString());
        }


        static int Solve(int n)
        {
            if (n < 0)
                return 0;
            if (n <= 1)
                return 1;

            if (!map.ContainsKey(n))
            {
                int count = Solve(n - 1) + Solve(n - 2) + Solve(n - 3);
                map[n] = count;
            }

            return map[n];
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

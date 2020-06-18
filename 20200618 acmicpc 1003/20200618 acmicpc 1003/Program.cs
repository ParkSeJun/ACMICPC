using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200618_acmicpc_1003
{
    class Program
    {
        public class D
        {
            public long zero;
            public long one;

            public D(long a, long b)
            {
                this.zero = a;
                this.one = b;
            }

            public static D operator +(D a, D b)
            {
                return new D(a.zero + b.zero, a.one + b.one);
            }

            public override string ToString()
            {
                return $"{zero} {one}";
            }
        }

        static Dictionary<int, D> map = new Dictionary<int, D>();

        static void Main(string[] args)
        {
            map[0] = new D(1, 0);
            map[1] = new D(0, 1);

            int count = int.Parse(Console.ReadLine().Trim());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(Console.ReadLine().Trim());
                sb.AppendLine(Solve(n).ToString());
            }
            Console.WriteLine(sb.ToString());
        }

        static D Solve(int n)
        {
            if (map.ContainsKey(n))
                return map[n];

            D a = Solve(n - 1);
            D b = Solve(n - 2);

            return map[n] = a + b;
        }


    }
}

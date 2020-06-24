using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200624_2193
{
    class Program
    {
        static Dictionary<int, long> dic = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            dic[0] = 0;
            dic[1] = 1;

            Console.WriteLine(Solve2(int.Parse(Console.ReadLine().Trim())));
        }

        static long Solve2(int len)
        {
            long a = 1;
            long b = 1;
            for (int i = 2; i < len; ++i)
            {
                long c = b;
                b += b;
                a = c;
            }
            return b;
        }

        static long Solve(int len)
        {
            if (!dic.ContainsKey(len))
            {
                dic[len] = Solve(len - 1) + Solve(len - 2);
            }

            return dic[len];
        }
    }
}

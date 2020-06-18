using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200618_acmicpc_1463
{
    class Program
    {
        static void Main(string[] args)
        {
            new A();
        }
    }

    class A
    {
        Dictionary<int, int> minPathMap;

        public A()
        {
            minPathMap = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            int a = Solve(n);
            Console.WriteLine(a);
        }

        int Solve(int n)
        {
            if (n == 1)
                return 0;

            // 최소값 구하기
            int min;
            if (minPathMap.ContainsKey(n))
            {
                min = minPathMap[n];
            }
            else
            {
                int div3 = n % 3 == 0 ? Solve(n / 3) : int.MaxValue;
                int div2 = (n & 1) == 0 ? Solve(n / 2) : int.MaxValue;
                int sub1 = Solve(n - 1);

                min = Math.Min(Math.Min(div3, div2), sub1) + 1;

                minPathMap[n] = min;
            }

            return min;
        }
    }
}

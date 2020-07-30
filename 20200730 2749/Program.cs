using System;
using System.Text;

namespace _20200730_2749
{
    class Program
    {
        static ulong p = 1000000;

        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            Console.WriteLine(GetFibo(n - 1));
        }

        static void Show(ulong[][] arr, ulong n, ulong m)
        {
            StringBuilder sb = new StringBuilder();
            for (ulong i = 0; i < n; i++)
            {
                for (ulong j = 0; j < m; j++)
                {
                    sb.Append(arr[i][j].ToString());
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        static ulong GetFibo(ulong n)
        {
            if (n+1 == 0)
                return 0;
            if (n+1 == 1)
                return 1;

            var root = new ulong[2][];
            for (ulong i = 0; i < 2; i++)
                root[i] = new ulong[2];
            root[0][0] = 1;
            root[0][1] = 1;
            root[1][0] = 1;
            root[1][1] = 0;

            var mul = new ulong[2][];
            for (ulong i = 0; i < 2; i++)
            {
                mul[i] = new ulong[1];
                mul[i][0] = 1 - i;
            }

            var ret = (ulong[][])root.Clone();
            while (n > 0)
            {
                if ((n & 1) == 1)
                    ret = Multi(ret, root, 2, 2, 2);
                root = Multi(root, root, 2, 2, 2);
                n /= 2;
            }

            ret = Multi(ret, mul, 2, 2, 1);
            //Show(ret, 2, 1);
            return ret[1][0];
        }

        static ulong[][] Multi(ulong[][] a, ulong[][] b, ulong n, ulong m, ulong l)
        {
            ulong[][] ret = new ulong[n][];
            for (ulong i = 0; i < n; i++)
            {
                ret[i] = new ulong[l];
                for (ulong j = 0; j < l; j++)
                {
                    ulong sum = 0;
                    for (ulong k = 0; k < m; k++)
                        sum = (sum + a[i][k] * b[k][j]) % p;
                    ret[i][j] = sum;
                }
            }
            return ret;
        }
    }
}

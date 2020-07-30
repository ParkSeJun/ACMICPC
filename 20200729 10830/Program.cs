using System;
using System.Text;
/*
3 3
1 2 3
4 5 6
7 8 9

468 576 684
62 305 548
656 34 412
*/


namespace _20200729_10830
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => long.Parse(e));
            long a = row[0];
            long b = row[1];
            long[][] arr = new long[a][];

            for (long i = 0; i < a; i++)
            {
                arr[i] = new long[a];
                row = Array.ConvertAll(Console.ReadLine().Split(' '), e => long.Parse(e));
                for (long j = 0; j < a; j++)
                    arr[i][j] = row[j];
            }

            long[][] ret = GetPow(arr, b, a);

            StringBuilder sb = new StringBuilder();
            for (long i = 0; i < a; i++)
            {
                for (long j = 0; j < a; j++)
                {
                    sb.Append(ret[i][j].ToString());
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        static long[][] GetPow(long[][] arr, long b, long size)
        {
            long[][] root = (long[][])arr.Clone();
            long[][] ret = new long[size][];
            for (int i = 0; i < size; i++)
            {
                ret[i] = new long[size];
                for (int j = 0; j < size; j++)
                    ret[i][j] = i == j ? 1 : 0;
            }
            while (b > 0)
            {
                if ((b & 1) == 1)
                    ret = Multi(ret, root, size);
                root = Multi(root, root, size);
                b /= 2;
            }
            return ret;
        }

        static long[][] Multi(long[][] arr, long[][] arr2, long size)
        {
            long[][] ret = new long[size][];
            for (long i = 0; i < size; i++)
            {
                ret[i] = new long[size];
                for (long j = 0; j < size; j++)
                {
                    long sum = 0;
                    for (long k = 0; k < size; k++)
                        sum = (sum + (arr[i][k] * arr2[k][j]) % 1000) % 1000;
                    ret[i][j] = sum;
                }
            }
            return ret;
        }
    }
}

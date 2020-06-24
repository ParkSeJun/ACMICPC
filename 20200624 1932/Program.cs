﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200624_1932
{
    class Program
    {
        class Pos
        {
            public static EqualityComparer comparer = new EqualityComparer();
            public int x, y;

            public Pos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public class EqualityComparer : IEqualityComparer<Pos>
            {
                bool IEqualityComparer<Pos>.Equals(Pos x, Pos y)
                {
                    return x.x == y.x && x.y == y.y;
                }

                int IEqualityComparer<Pos>.GetHashCode(Pos obj)
                {
                    return obj.GetHashCode();
                }
            }
        }

        static Dictionary<Pos, long> table = new Dictionary<Pos, long>(Pos.comparer);
        static int[][] arr;
        static void Main(string[] args)
        {
            /*
5
7
3 8
8 1 0
2 7 4 4
4 5 2 6 5
            30
             */
            int count = int.Parse(Console.ReadLine().Trim());
            arr = new int[count][];
            for (int i = 0; i < count; i++)
            {
                var inputs = Console.ReadLine().Trim().Split(' ');
                arr[i] = new int[count];
                for (int j = 0; j < inputs.Length; j++)
                {
                    arr[i][j] = int.Parse(inputs[j]);
                }
            }

            Console.WriteLine(Solve(new Pos(0, 0)));
        }

        static long Solve(Pos p)
        {
            if (p.y >= arr.Length)
                return 0;
            if (p.x > p.y)
                return 0;
            if (p.y == arr.Length - 1)
                return arr[p.y][p.x];

            if (!table.ContainsKey(p))
            {
                long a = Solve(new Pos(p.x, p.y + 1));
                long b = Solve(new Pos(p.x + 1, p.y + 1));
                long max = Math.Max(a, b) + arr[p.y][p.x];
                table[p] = max;
            }
            return table[p];
        }
    }
}

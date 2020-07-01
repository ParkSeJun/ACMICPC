using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701_12100_2
{
    class Program
    {
        public enum DIR
        {
            NONE,
            UP,
            LEFT,
            DOWN,
            RIGHT
        }

        static int[][] arr;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Trim());
            arr = new int[count][];
            for (int i = 0; i < count; ++i)
            {
                var row = Console.ReadLine().Trim().Split(' ');
                arr[i] = new int[count];
                for (int j = 0; j < count; j++)
                    arr[i][j] = int.Parse(row[j]);
            }

            var a = Solve(arr);
        }

        static int Solve(int[][] arr, DIR dir = DIR.NONE, int moveCount = 0)
        {
        }
    }
}

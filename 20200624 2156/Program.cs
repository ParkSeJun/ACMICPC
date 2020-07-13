using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200624_2156
{
    /*
6
6
10
13
9
8
1

        33.

6
999
999
1
1
999
999

        3996
    */
    class Program
    {
        static int[] table;
        static int[] arr;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Trim());
            arr = new int[count];
            table = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = int.Parse(Console.ReadLine().Trim());
                table[i] = 0;
            }

            for (int i = 0; i < count; i++)
            {
                int a = Get(table, i - 1);
                int b = Get(table, i - 2) + Get(arr, i);
                int c = Get(table, i - 3) + Get(arr, i - 1) + Get(arr, i);
                table[i] = Math.Max(a, Math.Max(b, c));
            }

            Console.WriteLine(table[count-1]);
        }

        static int Get(int[] arr, int i)
        {
            return i < 0 ? 0 : arr[i];
        }
    }
}

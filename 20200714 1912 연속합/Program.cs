/*
10
10 -4 3 1 5 6 -35 12 21 -1
33

10
2 1 -4 3 4 -4 6 5 -5 1
14

5
-1 -2 -3 -4 -5
-1
*/

using System;

namespace _20200714_1912
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            int[] table = new int[count];
            table[0] = arr[0];

            int max = table[0];
            for (int i = 1; i < count; i++)
            {
                if (table[i - 1] > 0)
                    table[i] = table[i - 1] + arr[i];
                else
                    table[i] = arr[i];
                if (max < table[i])
                    max = table[i];
            }

            Console.WriteLine(max);
        }
    }
}

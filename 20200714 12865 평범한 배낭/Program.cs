using System;
using System.Linq;
/*
4 7
6 13
4 8
3 6
5 12

14
*/

namespace _20200714_12865
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            int count = row[0];
            int weightLimit = row[1];

            int[][] arr = new int[2][];
            arr[0] = new int[count]; // W
            arr[1] = new int[count]; // V

            int[][] table = new int[2][];
            table[0] = new int[count];
            table[1] = new int[count];

            for (int i = 0; i < count; i++)
            {
                row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                arr[0][i] = row[0];
                arr[1][i] = row[1];
            }

            for (int i = 0; i < count; i++)
            {
                int maxValue = arr[1][i];
                int maxWeight = arr[0][i];
                for (int j = 0; j < i; j++)
                {
                    if (table[0][j] + arr[0][i] <= weightLimit && maxValue < table[1][j] + arr[1][i])
                    {
                        maxValue = table[1][j] + arr[1][i];
                        maxWeight = table[0][j] + arr[0][i];
                    }
                }
                if (arr[0][i] <= weightLimit)
                {
                    table[0][i] = maxWeight;
                    table[1][i] = maxValue ;
                }
                else
                {
                    table[0][i] = 0;
                    table[1][i] = 0;
                }
            }

            Console.WriteLine(table[1].Length == 0 ? 0 : table[1].Max());

        }
    }
}

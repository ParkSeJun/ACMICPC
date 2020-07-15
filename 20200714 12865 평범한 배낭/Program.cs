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

            for (int i = 0; i < count; i++)
            {
                row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                arr[0][i] = row[0];
                arr[1][i] = row[1];
            }

            int[][] table = new int[count][];
            for (int i = 0; i < count; i++)
            {
                table[i] = new int[weightLimit + 1];
                for (int j = 0; j < weightLimit + 1; j++)
                    table[i][j] = 0;
            }

            for (int i = arr[0][0]; i < weightLimit + 1; i++)
                table[0][i] = arr[1][0];

            for (int i = 1; i < count; i++)
                for (int j = 0; j < weightLimit + 1; j++)
                    table[i][j] = Math.Max(table[i - 1][j], (arr[0][i] <= j ? table[i - 1][j - arr[0][i]] + arr[1][i] : 0));

            Console.WriteLine(table[count - 1][weightLimit]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
10
1 5 2 1 4 3 4 5 2 1

    7

10
9 8 6 2 3 5 4 10 1 7

    6
 */
namespace _20200713_11054
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
            int[] arr = new int[count];
            int[][] table = new int[2][];
            for (int i = 0; i < 2; i++)
                table[i] = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = row[i];
                table[0][i] = 0;
                table[1][i] = 0;
            }

            int max;
            for (int i = 0; i < count; i++)
            {
                max = 0;
                for (int j = 0; j < i; j++)
                    if (arr[j] < arr[i] && max < table[0][j])
                        max = table[0][j];
                table[0][i] = max + 1;

                max = 0;
                for (int j = 0; j < i; j++)
                    if (arr[count - 1 - j] < arr[count - 1 - i] && max < table[1][count - 1 - j])
                        max = table[1][count - 1 - j];
                table[1][count - 1 - i] = max + 1;
            }

            max = 0;
            for (int i = 0; i < count; i++)
                if (max < table[0][i] + table[1][i])
                    max = table[0][i] + table[1][i];
            Console.WriteLine(max - 1);
        }
    }
}

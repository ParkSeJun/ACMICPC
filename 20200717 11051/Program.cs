using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
/*
5 2
10
*/
namespace _20200717_11051
{
    class Program
    {
        static int[][] arr;

        static void Main(string[] args)
        {
            //var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            //int n = row[0];
            //int k = row[1];

            int n = 1000;
            int k = 500;

            arr = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                arr[i] = new int[k + 1];
                for (int j = 0; j < k + 1; j++)
                    arr[i][j] = 0;
            }

            for (int i = 0; i < n + 1; i++)
                arr[i][0] = 1;
            for (int i = 0; i < k + 1; i++)
                arr[i][i] = 1;

            for (int i = 1; i < n + 1; i++)
                for (int j = 1; j < k + 1; j++)
                    arr[i][j] = arr[i - 1][j] + arr[i - 1][j - 1];

            Console.WriteLine(arr[n][k]);
        }
    }
}

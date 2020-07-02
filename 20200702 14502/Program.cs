using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

/*
7 7
2 0 0 0 1 1 0
0 0 1 0 1 2 0
0 1 1 0 1 0 0
0 1 0 0 0 0 0
0 0 0 0 0 1 1
0 1 0 0 0 0 0
0 1 0 0 0 0 0

27
*/
namespace _20200702_14502
{
    class Program
    {
        static int[][] arr;
        static int w, h;
        static List<int> virusList = new List<int>();
        static List<int> spaceList = new List<int>();

        static void Main(string[] args)
        {
            var row = Console.ReadLine().Split(' ');
            h = int.Parse(row[0]);
            w = int.Parse(row[1]);

            arr = new int[h][];
            for (int i = 0; i < h; i++)
            {
                arr[i] = new int[w];
                row = Console.ReadLine().Split(' ');
                for (int j = 0; j < w; j++)
                {
                    arr[i][j] = int.Parse(row[j]);
                    if (arr[i][j] == 0)
                        spaceList.Add(i * w + j);
                    else if (arr[i][j] == 2)
                        virusList.Add(i * w + j);
                }
            }


            int max = 0;
            for (int i = 0; i < spaceList.Count - 2; i++)
            {
                for (int j = i + 1; j < spaceList.Count - 1; j++)
                {
                    for (int k = j + 1; k < spaceList.Count; k++)
                    {
                        int sum = GetSafePoint(spaceList[i], spaceList[j], spaceList[k]);
                        if (max < sum)
                            max = sum;
                    }
                }
            }

            Console.WriteLine(max);
        }

        static int GetSafePoint(int a, int b, int c)
        {
            int[][] clone = new int[h][];
            for (int i = 0; i < h; i++)
            {
                clone[i] = new int[w];
                for (int j = 0; j < w; j++)
                {
                    clone[i][j] = arr[i][j];
                }
            }
            clone[a / w][a % w] = 1;
            clone[b / w][b % w] = 1;
            clone[c / w][c % w] = 1;

            Paint(clone);

            //if (a == 4 && b == 9 && c == 21)
            //{
            //    for (int i = 0; i < h; i++)
            //    {
            //        for (int j = 0; j < w; j++)
            //            Console.Write(clone[i][j]);
            //        Console.WriteLine();
            //    }
            //}

            int safePoint = 0;
            foreach (var pos in spaceList)
            {
                if (clone[pos / w][pos % w] == 0)
                    safePoint++;
            }

            return safePoint;
        }

        static void Paint(int[][] map)
        {
            List<int> virusArea = new List<int>();
            virusArea.AddRange(virusList);
            for (int i = 0; i < virusArea.Count; i++)
            {
                int thisPos = virusArea[i];
                int y = thisPos / w;
                int x = thisPos % w;

                if (IsValid(map, y, x + 1) && !virusArea.Contains(y * w + x + 1)) virusArea.Add(y * w + x + 1);
                if (IsValid(map, y, x - 1) && !virusArea.Contains(y * w + x - 1)) virusArea.Add(y * w + x - 1);
                if (IsValid(map, y + 1, x) && !virusArea.Contains((y + 1) * w + x)) virusArea.Add((y + 1) * w + x);
                if (IsValid(map, y - 1, x) && !virusArea.Contains((y - 1) * w + x)) virusArea.Add((y - 1) * w + x);

                map[y][x] = 2;
            }
        }

        static bool IsValid(int[][] map, int y, int x)
        {
            if (y < 0 || y >= h || x < 0 || x >= w)
                return false;
            if (map[y][x] != 0)
                return false;
            return true;
        }
    }
}

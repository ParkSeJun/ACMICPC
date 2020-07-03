using System;
using System.Collections.Generic;
using System.Linq;

namespace _20200703_14890
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
            int size = row[0];
            int len = row[1];

            int[][] arr = new int[size][];
            for (int i = 0; i < size; i++)
            {
                arr[i] = new int[size];
                row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
                for (int j = 0; j < size; j++)
                    arr[i][j] = row[j];
            }

            List<List<int>> lineList = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                List<int> a = new List<int>();
                for (int j = 0; j < size; j++)
                    a.Add(arr[i][j]);
                lineList.Add(a);

                a = new List<int>();
                for (int j = 0; j < size; j++)
                    a.Add(arr[j][i]);
                lineList.Add(a);
            }

            int sum = 0;
            foreach (var line in lineList)
            {
                List<bool> isRunway = new List<bool>();
                for (int i = 0; i < line.Count; i++)
                    isRunway.Add(false);

                bool isFail = false;
                for (int i = 0; i < size; i++)
                {
                    if (!IsValid(line, isRunway, i, len))
                    {
                        isFail = true;
                        break;
                    }
                }
                if (!isFail)
                    sum++;
            }
            Console.WriteLine(sum);
        }

        static bool IsValid(List<int> line, List<bool> isRunway, int index, int len)
        {
            int thisLevel = line[index];

            if (index - 1 >= 0)
            {
                if (line[index - 1] < thisLevel)
                {
                    if (index - len < 0)
                        return false;
                    for (int i = 0; i < len; i++)
                    {
                        if (line[index - i - 1] != thisLevel - 1 || isRunway[index - i - 1])
                            return false;
                        isRunway[index - i - 1] = true;
                    }
                }
            }

            if (index + 1 < line.Count)
            {
                if (line[index + 1] < thisLevel)
                {
                    if (index + len >= line.Count)
                        return false;
                    for (int i = 0; i < len; i++)
                    {
                        if (line[index + i + 1] != thisLevel - 1 || isRunway[index + i + 1])
                            return false;
                        isRunway[index + i + 1] = true;
                    }
                }
            }

            return true;
        }
    }
}

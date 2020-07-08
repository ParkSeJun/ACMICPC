using System;
using System.Collections.Generic;

namespace _20200708_6549
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                var row = Console.ReadLine().Split(' ');
                int count = int.Parse(row[0]);
                if (count == 0)
                    break;

                List<long> list = new List<long>();
                for (int i = 0; i < count; i++)
                    list.Add(int.Parse(row[i + 1]));

                long value = Solve(list);
                Console.WriteLine(value);
            }
        }

        static long Solve(List<long> list)
        {
            long max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int leftMostIndex = i;
                int rightMostIndex = i;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[j] < list[i])
                        break;
                    leftMostIndex = j;
                }
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[i])
                        break;
                    rightMostIndex = j;
                }

                long thisValue = list[i] * (rightMostIndex - leftMostIndex + 1);
                if (max < thisValue)
                    max = thisValue;
            }
            return max;
        }
    }
}

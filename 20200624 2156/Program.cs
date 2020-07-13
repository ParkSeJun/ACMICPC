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
        static Dictionary<KeyValuePair<int, int>, int> table = new Dictionary<KeyValuePair<int, int>, int>();
        static int[] arr;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Trim());
            arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = int.Parse(Console.ReadLine().Trim());
            }

            int ret = Solve(-1, -1);
            Console.WriteLine(ret);

            //foreach (var key in table.Keys)
            //{
            //    Console.WriteLine($"{key.Key}, {key.Value} : {table[key]}");
            //}
        }

        static int Solve(int index, int oneStepCount)
        {
            if (index >= arr.Length)
                return 0;

            if (oneStepCount >= 2)
                return 0;

            var key = new KeyValuePair<int, int>(index, oneStepCount);
            if (!table.ContainsKey(key))
            {
                int a = Solve(index + 1, oneStepCount + 1);
                List<int> bs = new List<int>();
                for (int i = 2; i < arr.Length - index; i++)
                    bs.Add(Solve(index + i, 0));
                int max = Math.Max(a, bs.Count == 0 ? 0 : bs.Max());
                table[key] = max + (index >= 0 ? arr[index] : 0);
            }

            return table[key];
        }
    }
}

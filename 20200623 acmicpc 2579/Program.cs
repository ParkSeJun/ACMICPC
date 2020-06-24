using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200623_acmicpc_2579
{
    class Program
    {
        static int[] arr;
        static Dictionary<KeyValuePair<int, int>, int> table = new Dictionary<KeyValuePair<int, int>, int>();

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Trim());
            arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = int.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine(Solve(-1, 0));
        }


        //static int Solve(int index, int acmlt, bool canGo1Step = true)
        //{
        //    if (index >= arr.Length)
        //        return int.MinValue;
        //    if (index == arr.Length - 1)
        //        return arr[index] + acmlt;

        //    var key = new KeyValuePair<int, bool>(index, canGo1Step);
        //    if (!table.ContainsKey(key))
        //    {
        //        int a = int.MinValue;
        //        if (canGo1Step)
        //            a = Solve(index + 1, arr[index] + acmlt, false);
        //        int b = Solve(index + 2, arr[index] + acmlt, true);



        //        table[key] = Math.Max(a, b);
        //    }

        //    return Math.Max(a, b);
        //}

        static int Solve(int index, int oneStepCount)
        {
            if (oneStepCount >= 2 || index >= arr.Length)
                return 0;

            if (index == arr.Length - 1)
                return arr[index];

            int score = 0;
            if (index >= 0)
                score = arr[index];

            var key = new KeyValuePair<int, int>(index, oneStepCount);
            if (!table.ContainsKey(key))
            {
                int a = Solve(index + 1, oneStepCount + 1);
                int b = Solve(index + 2, 1);

                table[key] = Math.Max(a, b) + score;
            }
            return table[key];
        }
    }
}

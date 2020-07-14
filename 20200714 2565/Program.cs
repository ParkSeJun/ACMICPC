using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
8
1 8
3 9
2 2
4 1
6 4
10 10
9 7
7 6

3
*/

namespace _20200714_2565
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Split();
                int a = int.Parse(row[0]);
                int b = int.Parse(row[1]);
                dic[a] = b;
            }

            var keys = dic.Keys.ToList();
            int[] arr = new int[keys.Count];
            int[] table = new int[keys.Count];
            for (int i = 0; i < keys.Count; i++)
            {
                arr[i] = dic[keys[i]];
                table[i] = 0;
            }

            for (int i = 0; i < keys.Count; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                    if (arr[j] < arr[i] && max < table[j])
                        max = table[j];
                table[i] = max + 1;
            }

            Console.WriteLine(keys.Count - table.Max());
        }
    }
}

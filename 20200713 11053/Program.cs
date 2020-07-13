using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200713_11053
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] arr = new int[count];
            int[] table = new int[count];
            var row = Console.ReadLine().Split(' ');
            for (int i = 0; i < count; i++)
            {
                arr[i] = int.Parse(row[i]);
                table[i] = 0;
            }

            for (int i = 0; i < count; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                    if (arr[j] < arr[i] && max < table[j])
                        max = table[j];
                table[i] = max + 1;
            }

            Console.WriteLine(table.Max());
        }
    }
}

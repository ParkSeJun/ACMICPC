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
            Dictionary<int, int> arr = new Dictionary<int, int>();
            Dictionary<int, List<int>> table = new Dictionary<int, List<int>>();
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Split();
                int a = int.Parse(row[0]);
                int b = int.Parse(row[1]);
                arr[a] = b;
                table[a] = new List<int>();
            }

            var arrKeys = new List<int>(arr.Keys);
            for (int i = 0; i < arr.Count; i++)
            {
                int thisA = arrKeys[i];
                int thisB = arr[thisA];
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i == j)
                        continue;

                    int thatA = arrKeys[j];
                    int thatB = arr[thatA];

                    if (thatA < thisA && thisB <= thatB ||
                        thisA < thatA && thatB <= thisB)
                        table[thisA].Add(thatA);
                }
                if (table[thisA].Count == 0)
                    table.Remove(thisA);
            }

            int removeCount = 0;
            while (true)
            {
                var tableKeys = new List<int>(table.Keys);
                int maxTableKey = 0;
                int maxTableValue = 0;
                for (int i = 0; i < table.Count; i++)
                {
                    int thisValue = table[tableKeys[i]].Count();
                    if (maxTableValue < thisValue)
                    {
                        maxTableValue = thisValue;
                        maxTableKey = tableKeys[i];
                    }
                }
                if (maxTableValue == 0)
                    break;

                for (int i = 0; i < tableKeys.Count; i++)
                {
                    int thisKey = tableKeys[i];
                    if (thisKey == maxTableKey)
                        continue;
                    List<int> p = table[thisKey];
                    if (p.Contains(maxTableKey))
                    {
                        p.Remove(maxTableKey);
                        if (p.Count == 0)
                            table.Remove(thisKey);
                    }
                }

                table.Remove(maxTableKey);
                removeCount++;
            }

            Console.WriteLine(removeCount);
        }
    }
}

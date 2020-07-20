using System;
using System.Collections.Generic;
using System.Linq;

/*
2
3
hat headgear
sunglasses eyewear
turban headgear
3
mask face
sunglasses face
makeup face

    5
    3
*/

namespace _20200720_9375
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int caseCount = int.Parse(Console.ReadLine());

            for (int @case = 0; @case < caseCount; @case++)
            {
                int count = int.Parse(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    var row = Console.ReadLine().Split(' ');
                    if (!dic.ContainsKey(row[1]))
                        dic[row[1]] = 0;
                    dic[row[1]]++;
                }
                var keys = dic.Keys.ToList();
                int sum = 1;
                for (int j = 0; j < keys.Count; j++)
                    sum *= dic[keys[j]] + 1;
                sum--;

                Console.WriteLine(sum);
                dic.Clear();
            }            
        }
    }
}

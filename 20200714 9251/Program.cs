using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200714_9251
{
    class Program
    {
        static void Main(string[] args)
        {
            var needle = Console.ReadLine();
            var haystack = Console.ReadLine();

            var bagOfChar = new Dictionary<char, List<int>>();
            for (int i = 0; i < needle.Length; i++)
            {
                if (!bagOfChar.ContainsKey(needle[i]))
                    bagOfChar[needle[i]] = new List<int>();
                bagOfChar[needle[i]].Insert(0, i); // 내림차순으로 들어가도록
            }

            List<int> validStr = new List<int>();
            for (int i = 0; i < haystack.Length; i++)
            {
                if (!bagOfChar.ContainsKey(haystack[i]))
                    continue;

                for (int j = 0; j < bagOfChar[haystack[i]].Count; j++)
                    validStr.Add(bagOfChar[haystack[i]][j]);
            }
            
            int[] table = new int[validStr.Count];
            for (int i = 0; i < table.Length; i++)
                table[i] = 0;

            for (int i = 0; i < validStr.Count; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                    if (validStr[j] < validStr[i] && max < table[j])
                        max = table[j];
                table[i] = max + 1;
            }

            Console.WriteLine(table.Length == 0 ? 0 : table.Max());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _20200731_10816
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            List<int> l = new List<int>();
            for (int i = 0; i < n; i++)
                l.Add(row[i]);
            l.Sort();

            n = int.Parse(Console.ReadLine());
            row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(GetCount(l, row[i]));
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }

        static int GetCount(List<int> l, int n)
        {
            int count = 0;

            int s = 0;
            int e = l.Count - 1;
            int findIndex = -1;
            while (s <= e)
            {
                int mid = (s + e) / 2;
                if (l[mid] == n)
                {
                    findIndex = mid;
                    break;
                }
                if (l[mid] < n)
                    s = mid + 1;
                else
                    e = mid - 1;
            }

            if (findIndex == -1)
                return 0;





            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _20200730_1920
{
    class Program
    {
        static List<int> l = new List<int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            for (int i = 0; i < n; i++)
                l.Add(row[i]);
            l.Sort();

            n = int.Parse(Console.ReadLine());
            row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.AppendLine(Find(row[i]) ? "1" : "0");
            }
            Console.WriteLine(sb.ToString());
        }

        static bool Find(int n)
        {
            int s = 0;
            int e = l.Count - 1;

            while (true)
            {
                int mid = (e - s) / 2 + s;
                int val = l[mid];
                if (val == n)
                    return true;

                if (val < n)
                {
                    s = mid + 1;
                }
                else
                {
                    e = mid - 1;
                }
                if (e < s)
                    break;
            }
            return false;
        }
    }
}

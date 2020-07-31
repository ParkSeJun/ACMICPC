using System;
using System.Collections.Generic;

/*
4 11
802
743
457
539

*/

namespace _20200731_1654
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e_ => int.Parse(e_));
            int c = row[0];
            int n = row[1];

            List<int> l = new List<int>();
            for (int i = 0; i < c; i++)
                l.Add(int.Parse(Console.ReadLine()));
            l.Sort();

            int s = 0;
            int e = l[l.Count - 1];
            int findN_1 = -1;
            int findN = -1;
            while (true)
            {
                int mid = (s + e) / 2;

                int sum = 0;
                for (int i = 0; i < l.Count; i++)
                    sum += l[i] / mid;

                if (sum == n)
                {
                    findN = mid;
                    if (findN != -1 && findN_1 != -1)
                        break;
                    s = mid + 1;
                }
                else if (sum == n - 1)
                {
                    findN_1 = mid;
                    if (findN != -1 && findN_1 != -1)
                        break;
                    e = mid - 1;
                }
                else if (sum < n)
                    e = mid - 1;
                else
                    s = mid + 1;
            }

            s = findN;
            e = findN_1;
            while (true)
            {
                if (s == e - 1)
                    break;

                int mid = (s + e) / 2;

                int sum = 0;
                for (int i = 0; i < l.Count; i++)
                    sum += l[i] / mid;

                if (sum == n)
                    s = mid;
                else if (sum == n - 1)
                    e = mid;
            }

            Console.WriteLine(s);
        }
    }
}

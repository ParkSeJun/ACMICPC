using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
/*
4
0 0
10 10
0 10
10 0

100
*/
namespace _20200730_2261
{
    class Program
    {
        class Pos
        {
            public int x, y;

            public Pos(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static List<Pos> l = new List<Pos>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                l.Add(new Pos(row[0], row[1]));
            }

            l.Sort((a, b) => a.x - b.x);



        }

        static int GetMin(int s, int e)
        {
            int mid = e / 2;
            int leftMin = GetMin(s, mid);
            int rightMin = GetMin(mid + 1, e);

            int min = Math.Min(leftMin, rightMin);
            int mids = mid;
            int mide = mid;
            for (int i = mid - 1; i >= s; i--)
            {
                int dist = (int)Math.Pow(l[i].x - l[mid].x, 2);
                if (dist > min)
                    break;

                mids = i;
            }
            for (int i = mid + 1; i <= e; i++)
            {
                int dist = (int)Math.Pow(l[i].x - l[mid].x, 2);
                if (dist > min)
                    break;

                mids = i;
            }

        }
    }
}

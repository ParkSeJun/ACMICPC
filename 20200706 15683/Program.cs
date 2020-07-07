using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _20200706_15683
{
    public class Program
    {
        [Flags]
        public enum DIR
        {
            NONE = 0,
            UP = 1 << 0,
            LEFT = 1 << 1,
            DOWN = 1 << 2,
            RIGHT = 1 << 3
        }

        public class Point
        {
            public int y, x;

            public Point(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }

        public class TV
        {
            public int type;
            public Point p;
            public DIR dir;
            public TV(int type, int y, int x, DIR dir = DIR.NONE)
            {
                this.type = type;
                this.p = new Point(y, x);
                this.dir = dir;
            }
            public TV(int type, Point p, DIR dir = DIR.NONE)
            {
                this.type = type;
                this.p = p;
                this.dir = dir;
            }
        }

        static List<Point> wallList = new List<Point>();
        static int w, h;

        static void Main(string[] args)
        {
            var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
            h = row[0];
            w = row[1];

            List<TV> tvList = new List<TV>();

            for (int i = 0; i < h; i++)
            {
                row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
                for (int j = 0; j < w; j++)
                {
                    int n = row[j];
                    switch (n)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            tvList.Add(new TV(n, i, j));
                            break;
                        case 6:
                            wallList.Add(new Point(i, j));
                            break;
                    }
                }
            }

            int a = Solve(tvList, 0);
        }

        static int Solve(List<TV> tvList, int index)
        {
            if (index == tvList.Count)
            {
                int ret = GetBlindSpotCount(tvList);
                return ret;
            }

            tvList

            int a, b, c, d = 0;
            switch (tvList[index].type)
            {
                case 1:
                    
                    break;
            }
        }

        static List<TV> GetClone(List<TV> tvList)
        {
            from e in tvList let e.p = new Point(e.p.y, e.p.x) 
        }

        static int GetBlindSpotCount(List<TV> tvList)
        {
            bool[][] arr = new bool[h][];
            for (int i = 0; i < h; i++)
            {
                arr[i] = new bool[w];
                for (int j = 0; j < w; j++)
                    arr[i][j] = false;
            }


            foreach (var tv in tvList)
            {
                Point nearWall;
                int t;

                if (tv.dir.HasEnumFlag(DIR.UP))
                {
                    nearWall = wallList.Where(e => e.x == tv.p.x && e.y < tv.p.y).OrderByDescending(e => e.y).Take(1).SingleOrDefault();
                    t = nearWall == null ? 0 : nearWall.y;
                    for (int i = tv.p.y; i <= t; i--)
                        arr[i][tv.p.x] = true;
                }
                if (tv.dir.HasEnumFlag(DIR.LEFT))
                {
                    nearWall = wallList.Where(e => e.y == tv.p.y && e.x < tv.p.x).OrderByDescending(e => e.x).Take(1).SingleOrDefault();
                    t = nearWall == null ? 0 : nearWall.x;
                    for (int i = tv.p.x; i <= t; i--)
                        arr[tv.p.y][i] = true;
                }
                if (tv.dir.HasEnumFlag(DIR.DOWN))
                {
                    nearWall = wallList.Where(e => e.x == tv.p.x && e.y > tv.p.y).OrderBy(e => e.y).Take(1).SingleOrDefault();
                    t = nearWall == null ? h - 1 : nearWall.y;
                    for (int i = tv.p.y; i >= t; i++)
                        arr[i][tv.p.x] = true;
                }
                if (tv.dir.HasEnumFlag(DIR.RIGHT))
                {
                    nearWall = wallList.Where(e => e.y == tv.p.y && e.x > tv.p.x).OrderBy(e => e.x).Take(1).SingleOrDefault();
                    t = nearWall == null ? w - 1 : nearWall.x;
                    for (int i = tv.p.x; i >= t; i++)
                        arr[tv.p.y][i] = true;
                }
            }

            foreach (var wall in wallList)
                arr[wall.y][wall.x] = true;

            int blindSpotSum = 0;
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    if (!arr[i][j])
                        blindSpotSum++;

            return blindSpotSum;
        }
    }

    public static class Extension
    {
        public static int ToInt(this Program.DIR dir)
        {
            return Convert.ToInt32(dir);
        }

        public static bool HasEnumFlag(this Program.DIR dir, Program.DIR flag)
        {
            int nDir = dir.ToInt();
            int nFlag = flag.ToInt();

            return (nDir & nFlag) == nFlag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static _20200630_12100.Program;

/*
3
2 2 2
4 4 4
8 8 8

16
*/

namespace _20200630_12100
{
    class Program
    {
        public class Block : ICloneable
        {
            public int y, x;
            public int value;
            public bool isActive;

            public Block(int y, int x, int value, bool isActive = true)
            {
                this.y = y;
                this.x = x;
                this.value = value;
                this.isActive = isActive;
            }

            object ICloneable.Clone()
            {
                return new Block(y, x, value, isActive);
            }

            public override string ToString()
            {
                return $"y{y} x{x} {value} {(isActive ? "" : "DIE")}";
            }
        }

        public enum DIR
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        static int count;
        static Dictionary<DIR, KeyValuePair<int, int>> moveDic = new Dictionary<DIR, KeyValuePair<int, int>>();
        static BoxComparer comparer = new BoxComparer();

        static void Main(string[] args)
        {
            moveDic[DIR.UP] = new KeyValuePair<int, int>(-1, 0);
            moveDic[DIR.DOWN] = new KeyValuePair<int, int>(1, 0);
            moveDic[DIR.LEFT] = new KeyValuePair<int, int>(0, -1);
            moveDic[DIR.RIGHT] = new KeyValuePair<int, int>(0, 1);

            List<Block> list = new List<Block>();

            //count = 3;
            //list.Add(new Block(0, 0, 2));
            //list.Add(new Block(0, 1, 2));
            //list.Add(new Block(0, 2, 2));
            //list.Add(new Block(1, 0, 4));
            //list.Add(new Block(1, 1, 4));
            //list.Add(new Block(1, 2, 4));
            //list.Add(new Block(2, 0, 8));
            //list.Add(new Block(2, 1, 8));
            //list.Add(new Block(2, 2, 8));

            count = int.Parse(Console.ReadLine().Trim()); // 1~20
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Trim().Split(' ');
                for (int j = 0; j < count; j++)
                {
                    int n = int.Parse(row[j]);
                    if (n > 0)
                    {
                        list.Add(new Block(i, j, n));
                    }
                }
            }

            var a = Solve(list, DIR.NONE, 0);
            Console.WriteLine(a);
        }

        static int Solve(List<Block> l, DIR dir, int moveCount)
        {
            if (dir != DIR.NONE)
            {
                var t = l.Clone();
                Move(l, dir);
                if (t.SequenceEqual(l, comparer))
                    return (from e in l select e.value).Max();
            }

            if (moveCount >= 5)
                return (from e in l select e.value).Max();

            int left = Solve(l.Clone(), DIR.LEFT, moveCount + 1);
            int up = Solve(l.Clone(), DIR.UP, moveCount + 1);
            int down = Solve(l.Clone(), DIR.DOWN, moveCount + 1);
            int right = Solve(l.Clone(), DIR.RIGHT, moveCount + 1);

            return Math.Max(up, Math.Max(down, Math.Max(left, right)));
        }

        static void Move(List<Block> l, DIR dir)
        {
            
            switch (dir)
            {
                case DIR.UP:
                    l.Sort(delegate (Block a, Block b) { return a.y - b.y; });
                    break;
                case DIR.DOWN:
                    l.Sort(delegate (Block a, Block b) { return b.y - a.y; });
                    break;
                case DIR.LEFT:
                    l.Sort(delegate (Block a, Block b) { return a.x - b.x; });
                    break;
                case DIR.RIGHT:
                    l.Sort(delegate (Block a, Block b) { return b.x - a.x; });
                    break;
            }

            foreach (var e in l)
            {
                if (!e.isActive)
                    continue;

                Block nearBlock = null;
                try
                {
                    switch (dir)
                    {
                        case DIR.UP:
                            nearBlock = (from ee in l where ee.isActive && ee.x == e.x && ee.y < e.y orderby ee.y descending select ee).ToList()[0];
                            break;
                        case DIR.DOWN:
                            nearBlock = (from ee in l where ee.isActive && ee.x == e.x && ee.y > e.y orderby ee.y ascending select ee).ToList()[0];
                            break;
                        case DIR.LEFT:
                            nearBlock = (from ee in l where ee.isActive && ee.y == e.y && ee.x < e.x orderby ee.x descending select ee).ToList()[0];
                            break;
                        case DIR.RIGHT:
                            nearBlock = (from ee in l where ee.isActive && ee.y == e.y && ee.x > e.x orderby ee.x ascending select ee).ToList()[0];
                            break;
                    }
                }
                catch (Exception ex)
                {
                    nearBlock = null;
                }

                if (nearBlock == null)
                {
                    switch (dir)
                    {
                        case DIR.UP:
                            e.y = 0;
                            break;
                        case DIR.DOWN:
                            e.y = count - 1;
                            break;
                        case DIR.LEFT:
                            e.x = 0;
                            break;
                        case DIR.RIGHT:
                            e.x = count - 1;
                            break;
                    }
                    continue;
                }

                if (e.value == nearBlock.value)
                {
                    nearBlock.value *= 2;
                    e.isActive = false;
                    continue;
                }

                e.y = nearBlock.y - moveDic[dir].Key;
                e.x = nearBlock.x - moveDic[dir].Value;
            }
        }

        public class BoxComparer : IEqualityComparer<Block>
        {
            bool IEqualityComparer<Block>.Equals(Block x, Block y)
            {
                return x.x == y.x && x.y == y.y && x.value == y.value && x.isActive == y.isActive;
            }

            int IEqualityComparer<Block>.GetHashCode(Block obj)
            {
                return obj.GetHashCode();
            }
        }


    }

    static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}

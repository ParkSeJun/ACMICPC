using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        struct Block
        {
            public int y, x;
            public int value;

            public Block(int y, int x, int value)
            {
                this.y = y;
                this.x = x;
                this.value = value;
            }

            public bool IsSameValue(Block other)
            {
                return value == other.value;
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

        static void Main(string[] args)
        {
            moveDic[DIR.UP] = new KeyValuePair<int, int>(-1, 0);
            moveDic[DIR.DOWN] = new KeyValuePair<int, int>(1, 0);
            moveDic[DIR.LEFT] = new KeyValuePair<int, int>(0, -1);
            moveDic[DIR.RIGHT] = new KeyValuePair<int, int>(0, 1);

            List<Block> list = new List<Block>();

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
                Move(l, dir);

            if (moveCount >= 5)
                return (from e in l orderby e.value descending select e.value).ElementAt(0);

            int left = Solve(GetClone(l), DIR.LEFT, moveCount + 1);
            int up = Solve(GetClone(l), DIR.UP, moveCount + 1);
            int down = Solve(GetClone(l), DIR.DOWN, moveCount + 1);
            int right = Solve(GetClone(l), DIR.RIGHT, moveCount + 1);

            return Math.Max(up, Math.Max(down, Math.Max(left, right)));
        }

        static List<Block> GetClone(List<Block> l)
        {
            return (from e in l select e).ToList();
        }

        static void Move(List<Block> l, DIR dir)
        {
            List<Block> order = null;
            switch (dir)
            {
                case DIR.UP:
                    order = (from e in l orderby e.y ascending select e).ToList();
                    break;
                case DIR.DOWN:
                    order = (from e in l orderby e.y descending select e).ToList();
                    break;
                case DIR.LEFT:
                    order = (from e in l orderby e.x ascending select e).ToList();
                    break;
                case DIR.RIGHT:
                    order = (from e in l orderby e.x descending select e).ToList();
                    break;
            }

            for (int i = 0; i < order.Count; ++i)
            {
                Block e = order[i];
                Block? nearBlock = null;
                try
                {
                    switch (dir)
                    {
                        case DIR.UP:
                            nearBlock = (from ee in order where ee.x == e.x && ee.y < e.y orderby ee.y descending select ee).ElementAt(0);
                            break;
                        case DIR.DOWN:
                            nearBlock = (from ee in order where ee.x == e.x && ee.y > e.y orderby ee.y ascending select ee).ElementAt(0);
                            break;
                        case DIR.LEFT:
                            nearBlock = (from ee in order where ee.y == e.y && ee.x < e.x orderby ee.x descending select ee).ElementAt(0);
                            break;
                        case DIR.RIGHT:
                            nearBlock = (from ee in order where ee.y == e.y && ee.x > e.x orderby ee.x ascending select ee).ElementAt(0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    nearBlock = null;
                }

                if (!nearBlock.HasValue)
                {
                    switch (dir)
                    {
                        case DIR.UP:
                            order[i] = new Block(0, e.x, e.value);
                            break;
                        case DIR.DOWN:
                            order[i] = new Block(count - 1, e.x, e.value);
                            break;
                        case DIR.LEFT:
                            order[i] = new Block(e.y, 0, e.value);
                            break;
                        case DIR.RIGHT:
                            order[i] = new Block(e.y, count - 1, e.value);
                            break;
                    }
                    continue;
                }

                if (e.IsSameValue(nearBlock.Value))
                {
                    int nearIndex = order.IndexOf(nearBlock.Value);
                    order[nearIndex] = new Block(nearBlock.Value.y, nearBlock.Value.x, nearBlock.Value.value * 2);
                    order.RemoveAt(i);
                    --i;
                    continue;
                }

                order[i] = new Block(nearBlock.Value.y - moveDic[dir].Key, nearBlock.Value.x - moveDic[dir].Value, e.value);
            }

            l = order;
        }
    }
}

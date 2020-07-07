using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace _20200707_19235_2
{
    /*
10
2 2 1
2 1 1
1 2 3
3 2 3
1 0 0
3 0 3
3 1 3
1 2 3
1 3 3
2 1 2
    */
    class Program
    {
        public class Point
        {
            public int y, x;

            public Point(int y, int x)
            {
                this.y = y;
                this.x = x;
            }

            public override string ToString()
            {
                return $"({y}, {x})";
            }
        }

        public class Block
        {
            public List<Point> list;

            public Block()
            {
                list = new List<Point>();
            }

            public Point this[int index]
            {
                get => list[index];
                set => list[index] = value;
            }

            public void Add(Point point)
            {
                list.Add(point);
            }

            public void MoveRight(int step = 1)
            {
                if (step == 0)
                    return;

                bool checkRemove = false;
                foreach (var e in list)
                {
                    e.x += step;
                    if (e.x >= w)
                        checkRemove = true;
                }

                if (!checkRemove)
                    return;

                bool isDirty;
                do
                {
                    isDirty = false;
                    foreach (var e in list)
                    {
                        if (e.x >= w)
                        {
                            list.Remove(e);
                            isDirty = true;
                            break;
                        }
                    }
                } while (isDirty);
            }

            public int GetRightmostX()
            {
                return list[list.Count - 1].x;
            }

            public int GetLeftmostX()
            {
                return list[0].x;
            }

            public bool HasPoint(Point p)
            {
                return list.Exists(e => e.y == p.y && e.x == p.x);
            }

            public bool HasPoint(int y, int x)
            {
                return list.Exists(e => e.y == y && e.x == x);
            }

            public void Remove(int y, int x)
            {
                var item = list.Find(e => e.y == y && e.x == x);
                list.Remove(item);
            }

            public override string ToString()
            {
                return string.Join(", ", list);
            }
        }

        static List<Block>[] blockLists = new List<Block>[2];
        static int h = 4;
        static int w = 6;

        static void Main(string[] args)
        {
            int score = 0;

            blockLists[0] = new List<Block>(); // 가로 
            blockLists[1] = new List<Block>(); // 세로


            Show();
            int count = int.Parse(Console.ReadLine());
            //int count = 10000;
            //int[] arr = new int[] { 2, 2, 1, 2, 1, 1, 1, 2, 3, 3, 2, 3, 1, 0, 0, 3, 0, 3, 3, 1, 3, 1, 2, 3, 1, 3, 3, 2, 1, 2, 2, 2, 1, 2, 1, 1, 1, 2, 3, 3, 2, 3, 1, 0, 0, 3, 0, 3, 3, 1, 3, 1, 2, 3, 1, 3, 3, 2, 1, 2 };
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                //var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
                var row = Console.ReadLine().Split(' ');
                int type = int.Parse(row[0]);
                int y = int.Parse(row[1]);
                int x = int.Parse(row[2]);
                //int type = rand.Next(1, 3); //arr[i * 3];
                //int y = rand.Next(0, 3);  //arr[i * 3 + 1];
                //int x = rand.Next(0, 3);  //arr[i * 3 + 2];

                Put(type, y, x);

                while (true)
                {
                    int ret = Clean(blockLists[0]);
                    if (ret == 0)
                        break;
                    score += ret;
                }
                Shift(blockLists[0]);

                while (true)
                {
                    int ret = Clean(blockLists[1]);
                    if (ret == 0)
                        break;
                    score += ret;
                }
                Shift(blockLists[1]);

                Show();
            }

            int ca = GetBlockCount();
            Console.WriteLine(score);
            Console.WriteLine(ca);
        }

        static int GetBlockCount()
        {
            int sum = 0;
            int len_blockLists = blockLists.Length;
            for (int i = 0; i < len_blockLists; ++i)
            {
                int len_blockList = blockLists[i].Count;
                for (int j = 0; j < len_blockList; j++)
                    sum += blockLists[i][j].list.Count;
            }
            return sum;
        }

        static bool Shift(List<Block> blockList)
        {
            int shiftRowCount = 0;
            for (int j = 0; j < w - h; ++j)
            {
                for (int i = 0; i < h; i++)
                {
                    if (HasBlock(blockList, i, j))
                    {
                        shiftRowCount++;
                        break;
                    }
                }
            }

            if (shiftRowCount == 0)
                return false;

            foreach (var b in blockList)
                b.MoveRight(shiftRowCount);
            GC(blockList);

            return true;
        }

        static int Clean(List<Block> blockList)
        {
            int score = 0;

            for (int j = w - h; j < w; ++j)
            {
                bool isFull = true;
                for (int i = 0; i < h; i++)
                {
                    if (!HasBlock(blockList, i, j))
                    {
                        isFull = false;
                        break;
                    }
                }

                if (isFull)
                {
                    for (int i = 0; i < h; i++)
                        Remove(blockList, i, j);
                    score++;
                }
            }

            blockList.Sort((a, b) => b.GetRightmostX() - a.GetRightmostX());
            int len_blockList = blockList.Count;
            for (int i = 0; i < len_blockList; ++i)
            {
                int canMoveStep = GetCanMoveStep(blockList, blockList[i]);
                blockList[i].MoveRight(canMoveStep);
            }

            GC(blockList);

            //foreach (var b in blockList)
            //    Debug.Assert(GetCanMoveStep(blockList, b) == 0);

            return score;
        }

        static void Put(int type, int y, int x)
        {
            Block b = new Block();
            b.Add(new Point(y, x));
            switch (type)
            {
                case 2:
                    b.Add(new Point(y, x + 1));
                    break;
                case 3:
                    b.Add(new Point(y + 1, x));
                    break;
            }
            var bT = Transpose(b);

            // 가로
            int leftmostX = b.GetLeftmostX();
            b.MoveRight(-leftmostX);
            blockLists[0].Add(b);
            int canMoveStep = GetCanMoveStep(blockLists[0], b);
            b.MoveRight(canMoveStep);

            // 세로
            leftmostX = bT.GetLeftmostX();
            bT.MoveRight(-leftmostX);
            blockLists[1].Add(bT);
            canMoveStep = GetCanMoveStep(blockLists[1], bT);
            bT.MoveRight(canMoveStep);
        }

        static void Show()
        {
            return;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Console.Write(HasBlock(blockLists[0], i, j) ? 1 : 0);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int j = 0; j < w; j++)
            {
                for (int i = h - 1; i >= 0; i--)
                {
                    Console.Write(HasBlock(blockLists[1], i, j) ? 1 : 0);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int GetCanMoveStep(List<Block> blockList, Block b)
        {
            for (int i = 1; ; ++i)
            {
                for (int j = b.list.Count - 1; j >= 0; --j)
                {
                    if (b[j].x + i >= w || HasBlock(blockList, b[j].y, b[j].x + i, b))
                        return i - 1;
                }
                Debug.Assert(i < w);
            }
        }

        static bool HasBlock(List<Block> blockList, int y, int x, Block except = null)
        {
            int len_blockList = blockList.Count;
            for (int i = 0; i < len_blockList; ++i)
            {
                Block thisBlock = blockList[i];
                if (except != null && ReferenceEquals(thisBlock, except))
                    continue;
                if (thisBlock.HasPoint(y, x))
                    return true;
            }
            return false;
        }

        static Block FindBlock(List<Block> blockList, int y, int x)
        {
            return blockList.Find(e => e.HasPoint(y, x));
        }

        static Block Transpose(Block b)
        {
            Block newBlock = new Block();
            for (int i = 0; i < b.list.Count; ++i)
                newBlock.Add(Transpose(b[i]));
            return newBlock;
        }

        static Point Transpose(Point p)
        {
            // (0, 0) -> (3, 0)
            // (0, 3) -> (0, 0)
            // (3, 0) -> (3, 3)
            // (3, 3) -> (0, 3)
            // yT = 3 - x
            // xT = y

            return new Point(h - p.x - 1, p.y);
        }

        static void GC(List<Block> blockList)
        {
            while (GC_(blockList)) ;
        }
        static bool GC_(List<Block> blockList)
        {
            foreach (var b in blockList)
            {
                if (b.list.Count == 0)
                {
                    blockList.Remove(b);
                    return true;
                }
            }
            return false;
        }

        static void Remove(List<Block> blockList, int y, int x)
        {
            FindBlock(blockList, y, x).Remove(y, x);
            GC(blockList);
        }
    }
}

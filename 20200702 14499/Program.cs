using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
4 2 0 0 8
0 2
3 4
5 6
7 8
4 4 4 1 3 3 3 2

0
0
3
0
0
8
6
3

*/

namespace _20200702_14499
{
    class Program
    {
        public enum DIR {
            EAST = 1,
            WEST,
            NORTH,
            SOUTH,
        }

        public class Dice
        {
            public int y, x;
            public int[] n;

            public Dice()
            {
                y = x = 0;
                n = new int[6];
                // 전개도 : T자형 중간0123 왼쪽4 오른쪽5
                n[0] = 0;
                n[1] = 0;
                n[2] = 0;
                n[3] = 0;
                n[4] = 0;
                n[5] = 0;
            }

            public int GetTop()
            {
                return n[0];
            }

            public int GetBottom()
            {
                return n[2];
            }

            public void SetBottom(int n)
            {
                this.n[2] = n;
            }

            public void Roll(DIR dir)
            {
                int t;
                switch (dir)
                {
                    case DIR.NORTH:
                        t = n[0];
                        n[0] = n[1];
                        n[1] = n[2];
                        n[2] = n[3];
                        n[3] = t;
                        y--;
                        break;
                    case DIR.SOUTH:
                        t = n[0];
                        n[0] = n[3];
                        n[3] = n[2];
                        n[2] = n[1];
                        n[1] = t;
                        y++;
                        break;
                    case DIR.WEST:
                        t = n[0];
                        n[0] = n[5];
                        n[5] = n[2];
                        n[2] = n[4];
                        n[4] = t;
                        x--;
                        break;
                    case DIR.EAST:
                        t = n[0];
                        n[0] = n[4];
                        n[4] = n[2];
                        n[2] = n[5];
                        n[5] = t;
                        x++;
                        break;
                }
            }
            public override string ToString()
            {
                return string.Join(" ", n);
            }
        }



        static void Main(string[] args)
        {
            Dice dice = new Dice();
            int[][] arr;
            List<int> moveList = new List<int>();

            var row = Console.ReadLine().Split(' ');

            int h = int.Parse(row[0]);
            int w = int.Parse(row[1]);
            arr = new int[h][];
            for (int i = 0; i < h; i++)
                arr[i] = new int[w];

            int y = int.Parse(row[2]);
            int x = int.Parse(row[3]);
            dice.y = y;
            dice.x = x;
            
            int moveCount = int.Parse(row[4]);

            for (int i = 0; i < h; i++)
            {
                row = Console.ReadLine().Split(' ');
                for (int j = 0; j < w; j++)
                {
                    arr[i][j] = int.Parse(row[j]);
                }
            }

            row = Console.ReadLine().Split(' ');
            for (int i = 0; i < moveCount; i++)
            {
                moveList.Add(int.Parse(row[i]));
            }

            foreach (var move in moveList)
            {
                DIR dir = (DIR)Enum.ToObject(typeof(DIR), move);

                switch (dir)
                {
                    case DIR.EAST:
                        if (dice.x >= w - 1)
                            continue;
                        break;
                    case DIR.WEST:
                        if (dice.x < 1)
                            continue;
                        break;
                    case DIR.NORTH:
                        if (dice.y < 1)
                            continue;
                        break;
                    case DIR.SOUTH:
                        if (dice.y >= h - 1)
                            continue;
                        break;
                }

                dice.Roll(dir);



                if (arr[dice.y][dice.x] != 0)
                {
                    dice.SetBottom(arr[dice.y][dice.x]);
                    arr[dice.y][dice.x] = 0;
                }
                else
                    arr[dice.y][dice.x] = dice.GetBottom();

                Console.WriteLine(dice.GetTop());
            }
        }
    }
}

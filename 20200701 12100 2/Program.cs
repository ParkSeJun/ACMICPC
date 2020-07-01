using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20200701_12100_2
{
    class Program
    {
        public enum DIR
        {
            NONE,
            UP,
            LEFT,
            DOWN,
            RIGHT
        }

        class Pos
        {
            public int y, x;

            public Pos(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }


        static int count;
        static int[][] arr;

        static void Main(string[] args)
        {
            count = int.Parse(Console.ReadLine().Trim());
            arr = new int[count][];
            for (int i = 0; i < count; ++i)
            {
                var row = Console.ReadLine().Trim().Split(' ');
                arr[i] = new int[count];
                for (int j = 0; j < count; j++)
                    arr[i][j] = int.Parse(row[j]);
            }

            var a = Solve(arr);
            Console.WriteLine(a);
        }

        static int Solve(int[][] arr, DIR dir = DIR.NONE, int moveCount = 0)
        {
            if (dir != DIR.NONE)
            {
                var newArr = Move(arr, dir);
                if (SameArr(arr, newArr))
                    return GetMax(newArr);
                arr = newArr;
            }

            if (moveCount == 5)
                return GetMax(arr);


            int up = Solve(arr, DIR.UP, moveCount + 1);
            int left = Solve(arr, DIR.LEFT, moveCount + 1);
            int down = Solve(arr, DIR.DOWN, moveCount + 1);
            int right = Solve(arr, DIR.RIGHT, moveCount + 1);

            return Math.Max(up, Math.Max(left, Math.Max(down, right)));
        }

        static int[][] Move(int[][] input, DIR dir)
        {
            int[][] arr = new int[count][];
            for (int i = 0; i < count; ++i)
            {
                arr[i] = new int[count];
                for (int j = 0; j < count; j++)
                    arr[i][j] = input[i][j];
            }

            int moveY;
            int moveX;
            switch (dir)
            {
                case DIR.UP:
                    moveY = -1;
                    moveX = 0;
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            if (arr[i][j] == 0)
                                continue;

                            // 앞블록 체크
                            Pos nearBlock = GetNearBlock(arr, i, j, moveY, moveX);
                            if (nearBlock == null)
                            {
                                int t = arr[i][j];
                                arr[i][j] = 0;
                                arr[0][j] = t;
                            }
                            else
                            {
                                if (arr[nearBlock.y][nearBlock.x] == arr[i][j])
                                {
                                    arr[nearBlock.y][nearBlock.x] *= 2;
                                    arr[i][j] = 0;
                                }
                                else
                                {
                                    int t = arr[i][j];
                                    arr[i][j] = 0;
                                    arr[nearBlock.y - moveY][nearBlock.x - moveX] = t;
                                }
                            }
                        }
                    }
                    break;
                case DIR.LEFT:
                    moveY = 0;
                    moveX = -1;
                    for (int j = 0; j < count; j++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (arr[i][j] == 0)
                                continue;

                            // 앞블록 체크
                            Pos nearBlock = GetNearBlock(arr, i, j, moveY, moveX);
                            if (nearBlock == null)
                            {
                                int t = arr[i][j];
                                arr[i][j] = 0;
                                arr[0][j] = t;
                            }
                            else
                            {
                                if (arr[nearBlock.y][nearBlock.x] == arr[i][j])
                                {
                                    arr[nearBlock.y][nearBlock.x] *= 2;
                                    arr[i][j] = 0;
                                }
                                else
                                {
                                    int t = arr[i][j];
                                    arr[i][j] = 0;
                                    arr[nearBlock.y - moveY][nearBlock.x - moveX] = t;
                                }
                            }
                        }
                    }
                    break;
                case DIR.DOWN:
                    moveY = 1;
                    moveX = 0;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            if (arr[i][j] == 0)
                                continue;

                            // 앞블록 체크
                            Pos nearBlock = GetNearBlock(arr, i, j, moveY, moveX);
                            if (nearBlock == null)
                            {
                                int t = arr[i][j];
                                arr[i][j] = 0;
                                arr[0][j] = t;
                            }
                            else
                            {
                                if (arr[nearBlock.y][nearBlock.x] == arr[i][j])
                                {
                                    arr[nearBlock.y][nearBlock.x] *= 2;
                                    arr[i][j] = 0;
                                }
                                else
                                {
                                    int t = arr[i][j];
                                    arr[i][j] = 0;
                                    arr[nearBlock.y - moveY][nearBlock.x - moveX] = t;
                                }
                            }
                        }
                    }
                    break;
                case DIR.RIGHT:
                    moveY = 0;
                    moveX = 1;
                    for (int j = count - 1; j >= 0; j--)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (arr[i][j] == 0)
                                continue;

                            // 앞블록 체크
                            Pos nearBlock = GetNearBlock(arr, i, j, moveY, moveX);
                            if (nearBlock == null)
                            {
                                int t = arr[i][j];
                                arr[i][j] = 0;
                                arr[0][j] = t;
                            }
                            else
                            {
                                if (arr[nearBlock.y][nearBlock.x] == arr[i][j])
                                {
                                    arr[nearBlock.y][nearBlock.x] *= 2;
                                    arr[i][j] = 0;
                                }
                                else
                                {
                                    int t = arr[i][j];
                                    arr[i][j] = 0;
                                    arr[nearBlock.y - moveY][nearBlock.x - moveX] = t;
                                }
                            }
                        }
                    }
                    break;
            }

            return arr;
        }

        static Pos GetNearBlock(int[][] arr, int y, int x, int moveY, int moveX)
        {
            y += moveY;
            x += moveX;
            while (true)
            {
                if (y < 0 || y >= count || x < 0 || x >= count)
                    return null;

                if (arr[y][x] != 0)
                    break;

                y += moveY;
                x += moveX;
            }

            return new Pos(y, x);
        }

        static bool SameArr(int[][] A, int[][] B)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (A[i][j] != B[i][j])
                        return false;
                }
            }
            return true;
        }

        static int GetMax(int[][] arr)
        {
            int max = 0;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (max < arr[i][j])
                        max = arr[i][j];
                }
            }
            return max;
        }
    }
}

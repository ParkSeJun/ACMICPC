using System;
using System.Collections.Generic;

/* 
5 5
#####
#..B#
#.#.#
#RO.#
#####

1
*/

namespace _20200625_13460
{
    class Program
    {
        enum DIR
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
        public struct Result
        {
            public enum ResultValue
            {
                FAIL,
                NORMAL,
                CLEAR,
            }

            public KeyValuePair<int, int> B, R;
            public ResultValue result;

            public Result(KeyValuePair<int, int> B, KeyValuePair<int, int> R, ResultValue result)
            {
                this.B = B;
                this.R = R;
                this.result = result;
            }
        }

        static bool IsEqual(KeyValuePair<int, int> a, KeyValuePair<int, int> b) => a.Key == b.Key && a.Value == b.Value;

        static Dictionary<DIR, KeyValuePair<int, int>> moveDic = new Dictionary<DIR, KeyValuePair<int, int>>();

        static KeyValuePair<int, int> hole;
        static HashSet<KeyValuePair<int, int>> walls = new HashSet<KeyValuePair<int, int>>();
        static char[][] arr;
        static KeyValuePair<int, int> @default = new KeyValuePair<int, int>(-1, -1);

        static void Main(string[] args)
        {
            KeyValuePair<int, int> B = @default, R = @default;

            var inputs = Console.ReadLine().Trim().Split(' ');
            int h = int.Parse(inputs[0]);
            int w = int.Parse(inputs[1]);
            arr = new char[h][];
            for (int i = 0; i < h; i++)
            {
                arr[i] = new char[w];
                string row = Console.ReadLine().Trim();
                for (int j = 0; j < w; j++)
                {
                    arr[i][j] = row[j];

                    switch (arr[i][j])
                    {
                        case '#':
                            walls.Add(new KeyValuePair<int, int>(i, j));
                            break;
                        case 'O':
                            hole = new KeyValuePair<int, int>(i, j);
                            break;
                        case 'B':
                            B = new KeyValuePair<int, int>(i, j);
                            break;
                        case 'R':
                            R = new KeyValuePair<int, int>(i, j);
                            break;
                    }
                }
            }

            moveDic[DIR.UP] = new KeyValuePair<int, int>(-1, 0);
            moveDic[DIR.DOWN] = new KeyValuePair<int, int>(1, 0);
            moveDic[DIR.LEFT] = new KeyValuePair<int, int>(0, -1);
            moveDic[DIR.RIGHT] = new KeyValuePair<int, int>(0, 1);

            var a = Solve(B, R, DIR.NONE, 0);
            if (a > 10)
                Console.WriteLine(-1);
            else
                Console.WriteLine(a);
        }

        static int Solve(KeyValuePair<int, int> B, KeyValuePair<int, int> R, DIR preDir, int tiltCount)
        {
            if (tiltCount > 10)
                return int.MaxValue;

            // Update
            Result result = Move(B, R, preDir);
            if (preDir != DIR.NONE && IsEqual(B, result.B) && IsEqual(R, result.R))
                return int.MaxValue;

            B = result.B;
            R = result.R;

            // Clear Check
            if (result.result == Result.ResultValue.FAIL)
                return int.MaxValue;

            if (result.result == Result.ResultValue.CLEAR)
                return tiltCount;

            // Recur (Without preDir)
            int UP = preDir != DIR.UP && preDir != DIR.DOWN ? Solve(B, R, DIR.UP, tiltCount + 1) : int.MaxValue;
            int LEFT = preDir != DIR.LEFT && preDir != DIR.RIGHT ? Solve(B, R, DIR.LEFT, tiltCount + 1) : int.MaxValue;
            int DOWN = preDir != DIR.UP && preDir != DIR.DOWN ? Solve(B, R, DIR.DOWN, tiltCount + 1) : int.MaxValue;
            int RIGHT = preDir != DIR.LEFT && preDir != DIR.RIGHT ? Solve(B, R, DIR.RIGHT, tiltCount + 1) : int.MaxValue;

            return Math.Min(UP, Math.Min(LEFT, Math.Min(DOWN, RIGHT)));

        }

        static Result Move(KeyValuePair<int, int> B, KeyValuePair<int, int> R, DIR dir)
        {
            if (dir == DIR.NONE)
                return new Result(B, R, Result.ResultValue.NORMAL);

            KeyValuePair<int, int> first = @default, second = @default;
            bool B_First = false;

            switch (dir)
            {
                case DIR.UP:
                    first = B.Key < R.Key ? B : R;
                    second = B.Key < R.Key ? R : B;
                    break;
                case DIR.DOWN:
                    first = B.Key > R.Key ? B : R;
                    second = B.Key > R.Key ? R : B;
                    break;
                case DIR.LEFT:
                    first = B.Value < R.Value ? B : R;
                    second = B.Value < R.Value ? R : B;
                    break;
                case DIR.RIGHT:
                    first = B.Value > R.Value ? B : R;
                    second = B.Value > R.Value ? R : B;
                    break;
            }

            B_First = IsEqual(first, B);

            bool R_in_hole = false;

            // first
            while (true)
            {
                var temp = new KeyValuePair<int, int>(first.Key + moveDic[dir].Key, first.Value + moveDic[dir].Value);
                if (walls.Contains(temp)) // 벽
                    break;
                if (IsEqual(hole, temp)) // 구멍
                {
                    if (B_First)
                        return new Result(@default, @default, Result.ResultValue.FAIL);
                    else
                    {
                        R_in_hole = true;
                        first = new KeyValuePair<int, int>(-999, -999);
                    }
                    break;
                }
                first = temp;
            }

            // second
            while (true)
            {
                var temp = new KeyValuePair<int, int>(second.Key + moveDic[dir].Key, second.Value + moveDic[dir].Value);
                if (walls.Contains(temp)) // 벽
                    break;
                if (IsEqual(hole, temp)) // 구멍
                {
                    if (B_First)
                        R_in_hole = true;
                    else
                        return new Result(@default, @default, Result.ResultValue.FAIL);
                    break;
                }
                if (IsEqual(first, temp))
                    break;
                second = temp;
            }

            if (R_in_hole)
                return new Result(@default, @default, Result.ResultValue.CLEAR);

            if (B_First)
                return new Result(first, second, Result.ResultValue.NORMAL);
            return new Result(second, first, Result.ResultValue.NORMAL);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200702_14503
{
    class Program
    {
        public enum DIR
        {
            UP = 0,
            RIGHT,
            DOWN,
            LEFT,
            SIZE
        }

        static Dictionary<DIR, KeyValuePair<int, int>> moveDic = new Dictionary<DIR, KeyValuePair<int, int>>();
        static int h, w;

        static void Main(string[] args)
        {
            moveDic[DIR.RIGHT] = new KeyValuePair<int, int>(0, 1);
            moveDic[DIR.LEFT] = new KeyValuePair<int, int>(0, -1);
            moveDic[DIR.DOWN] = new KeyValuePair<int, int>(1, 0);
            moveDic[DIR.UP] = new KeyValuePair<int, int>(-1, 0);

            int y, x;
            DIR dir;
            int clearCount = 0;
            byte[][] arr;

            var row = Console.ReadLine().Split(' ');
            h = int.Parse(row[0]);
            w = int.Parse(row[1]);

            row = Console.ReadLine().Split(' ');
            y = int.Parse(row[0]);
            x = int.Parse(row[1]);
            dir = int.Parse(row[2]).ToEnum<DIR>();

            arr = new byte[h][];
            for (int i = 0; i < h; i++)
            {
                arr[i] = new byte[w];
                row = Console.ReadLine().Split(' ');
                for (int j = 0; j < w; j++)
                    arr[i][j] = byte.Parse(row[j]);
            }

            while (true)
            {
                if (arr[y][x] == 0)
                {
                    arr[y][x] = 2;
                    clearCount++;
                }

                DIR left = ((dir.ToInt() - 1 + DIR.SIZE.ToInt()) % DIR.SIZE.ToInt()).ToEnum<DIR>();

                if (arr[y + moveDic[left].Key][x + moveDic[left].Value] == 0)
                {
                    dir = left;
                    y += moveDic[dir].Key;
                    x += moveDic[dir].Value;
                    continue;
                }

                bool isLeftValid = arr[y + moveDic[DIR.LEFT].Key][x + moveDic[DIR.LEFT].Value] == 0;
                bool isDownValid = arr[y + moveDic[DIR.DOWN].Key][x + moveDic[DIR.DOWN].Value] == 0;
                bool isRightValid = arr[y + moveDic[DIR.RIGHT].Key][x + moveDic[DIR.RIGHT].Value] == 0;
                bool isUpValid = arr[y + moveDic[DIR.UP].Key][x + moveDic[DIR.UP].Value] == 0;
                if (!isLeftValid && !isDownValid && !isRightValid && !isUpValid)
                {
                    DIR behind = ((dir.ToInt() - 2 + DIR.SIZE.ToInt()) % DIR.SIZE.ToInt()).ToEnum<DIR>();
                    if (arr[y + moveDic[behind].Key][x + moveDic[behind].Value] == 1)
                        break;
                    y -= moveDic[dir].Key;
                    x -= moveDic[dir].Value;
                    continue;
                }

                dir = left;
            }

            Console.WriteLine(clearCount);

        }


    }

    static class Extension
    {
        public static T ToEnum<T>(this int n) where T : IConvertible
        {
            return (T)Enum.ToObject(typeof(T), n);
        }

        public static int ToInt(this Program.DIR dir)
        {
            return Convert.ToInt32(dir);
        }
    }
}

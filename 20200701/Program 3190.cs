using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701
{
    class Program
    {
        public enum DIR
        {
            UP,
            RIGHT,
            DOWN,
            LEFT
        }

        public class Data
        {
            public bool isItem;
            public int snakeCount;

            public Data(bool isItem)
            {
                this.snakeCount = 0;
                this.isItem = isItem;
            }

            public Data(int snakeCount)
            {
                this.snakeCount = snakeCount;
                this.isItem = false;
            }
        }

        static void Main(string[] args)
        {
            DIR myDir = DIR.RIGHT;
            Dictionary<int, Data> dic = new Dictionary<int, Data>();
            Dictionary<int, char> actDic = new Dictionary<int, char>();
            int size = int.Parse(Console.ReadLine());
            int itemCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < itemCount; i++)
            {
                var row = Console.ReadLine().Split(' ');
                int y_ = int.Parse(row[0]);
                int x_ = int.Parse(row[1]);
                dic[GetPos(y_, x_)] = new Data(isItem: true);
            }
            int actCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < actCount; i++)
            {
                var row = Console.ReadLine().Split(' ');
                int time = int.Parse(row[0]);
                char dir = char.Parse(row[1]);
                actDic[time] = dir;
            }

            dic[GetPos(0, 0)] = new Data(1);

            Display(dic, size);

            int sec = 0;
            int y = 0, x = 0;
            int snakeLength = 1;
            while (true)
            {
                switch (myDir)
                {
                    case DIR.UP:
                        y--;
                        break;
                    case DIR.RIGHT:
                        x++;
                        break;
                    case DIR.DOWN:
                        y++;
                        break;
                    case DIR.LEFT:
                        x--;
                        break;
                }

                foreach (var e in dic)
                {
                    if (e.Value.snakeCount > 0)
                        e.Value.snakeCount--;
                }

                foreach (var e in from d in dic where d.Value.snakeCount <= 0 select d)
                {
                    dic.Remove(e.Key);
                }

                if (!dic.ContainsKey(GetPos(y, x)))
                    dic[GetPos(y, x)] = new Data(snakeLength);
                else
                    dic[GetPos(y, x)].snakeCount = snakeLength;

                sec++;

                Display(dic, size);
                Console.ReadLine();
            }

        }

        static void Display(Dictionary<int, Data> dic, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (dic.ContainsKey(GetPos(i, j)))
                    {
                        if (dic[GetPos(i, j)].isItem)
                            Console.Write("x");
                        else
                            Console.Write("o");
                    }
                    else
                        Console.Write("-");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int GetPos(int y, int x)
        {
            return y * 1000 + x;
        }
    }
}

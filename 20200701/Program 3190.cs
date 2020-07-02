using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701
{
    /*
6
3
3 4
2 5
5 3
3
3 D
15 L
17 D

        9
    */
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
                int y_ = int.Parse(row[0]) - 1;
                int x_ = int.Parse(row[1]) - 1;
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

            dic[GetPos(0, 0)] = new Data(2);

            //Display(dic, size);

            int sec = 0;
            int y = 0, x = 0;
            int snakeLength = 2;
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

                bool isMeetItem = false;
                if (dic.ContainsKey(GetPos(y, x)) && dic[GetPos(y, x)].isItem)
                {
                    snakeLength++;
                    isMeetItem = true;
                    dic.Remove(GetPos(y, x));
                }

                if (!isMeetItem)
                {
                    foreach (var e in dic)
                    {
                        if (e.Value.snakeCount > 0)
                            e.Value.snakeCount--;
                    }

                    List<int> removeList = new List<int>();
                    foreach (var e in from d in dic where !d.Value.isItem && d.Value.snakeCount <= 0 select d)
                    {
                        removeList.Add(e.Key);
                    }
                    foreach (var e in removeList)
                    {
                        dic.Remove(e);
                    }
                }

                sec++;

                if (y < 0 || y >= size || x < 0 || x >= size || (dic.ContainsKey(GetPos(y, x)) && dic[GetPos(y, x)].snakeCount > 0))
                {
                    break;
                }

                if (!dic.ContainsKey(GetPos(y, x)))
                    dic[GetPos(y, x)] = new Data(snakeLength);
                else
                    dic[GetPos(y, x)].snakeCount = snakeLength;

                if (actDic.ContainsKey(sec))
                {
                    switch (actDic[sec])
                    {
                        case 'L':
                            myDir--;
                            break;
                        case 'D':
                            myDir++;
                            break;
                    }
                    myDir = (DIR)Enum.ToObject(typeof(DIR), (Convert.ToInt32(myDir) + Convert.ToInt32(DIR.SIZE)) % Convert.ToInt32(DIR.SIZE));
                }

                //Console.WriteLine(sec);
                //Display(dic, size);
                //Console.ReadLine();
            }
            Console.WriteLine(sec);
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
                            Console.Write(dic[GetPos(i, j)].snakeCount);
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

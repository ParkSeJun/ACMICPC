using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200707_19235
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;

            bool[][] green;
            green = new bool[6][];
            for (int i = 0; i < 6; i++)
            {
                green[i] = new bool[4];
                for (int j = 0; j < 4; j++)
                    green[i][j] = false;
            }

            bool[][] blue;
            blue = new bool[4][];
            for (int i = 0; i < 4; i++)
            {
                blue[i] = new bool[6];
                for (int j = 0; j < 6; j++)
                    blue[i][j] = false;
            }

            Show(green, blue);
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
                int type = row[0];
                int y = row[1];
                int x = row[2];

                Put(green, blue, y, x, type);

                while (true)
                {
                    int ret = Clean(green, blue);
                    if (ret == 0)
                        break;
                    score += ret;
                }

                if (Shift(green, blue))
                {
                    while (true)
                    {
                        int ret = Clean(green, blue);
                        if (ret == 0)
                            break;
                        score += ret;
                    }
                }
                Show(green, blue);
            }

            int c = GetBlockCount(green, blue);
            Console.WriteLine(score);
            Console.WriteLine(c);

        }

        static int GetBlockCount(bool[][] green, bool[][] blue)
        {
            int count = 0;
            for (int i = 2; i < 6; ++i)
                for (int j = 0; j < 4; ++j)
                    if (green[i][j])
                        count++;
            for (int j = 2; j < 6; ++j)
                for (int i = 0; i < 4; ++i)
                    if (blue[i][j])
                        count++;
            return count;
        }

        static void Show(bool[][] green, bool[][] blue)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(green[i][j] ? 1 : 0);
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                    Console.Write(blue[i][j] ? 1 : 0);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Put(bool[][] green, bool[][] blue, int y, int x, int type)
        {
            int putY = -1;
            for (int i = 0; i < 6; i++)
            {
                if (green[i][x] || (type == 3 && (i + 1 == 6 || green[i + 1][x])) || (type == 2 && green[i][x + 1]))
                    break;
                putY = i;
            }
            switch (type)
            {
                case 1:
                    green[putY][x] = true;
                    break;
                case 2:
                    green[putY][x] = true;
                    green[putY][x + 1] = true;
                    break;
                case 3:
                    green[putY][x] = true;
                    green[putY + 1][x] = true;
                    break;
            }

            int putX = -1;
            for (int j = 0; j < 6; j++)
            {
                if (blue[y][j] || (type == 2 && (j + 1 == 6 || blue[y][j + 1])) || (type == 3 && blue[y + 1][j]))
                    break;
                putX = j;
            }
            switch (type)
            {
                case 1:
                    blue[y][putX] = true;
                    break;
                case 2:
                    blue[y][putX] = true;
                    blue[y][putX + 1] = true;
                    break;
                case 3:
                    blue[y][putX] = true;
                    blue[y + 1][putX] = true;
                    break;
            }
        }

        static int Clean(bool[][] green, bool[][] blue)
        {
            int greenCleanCount = 0;
            int blueCleanCount = 0;

            for (int i = 2; i < 6; ++i)
            {
                bool isFull = true;
                for (int j = 0; j < 4; j++)
                {
                    if (!green[i][j])
                    {
                        isFull = false;
                        break;
                    }
                }

                if (isFull)
                {
                    for (int j = 0; j < 4; j++)
                        green[i][j] = false;
                    greenCleanCount++;
                }
            }

            // Push
            if (greenCleanCount > 0)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int i = 6 - 1 - 1; i >= 0; --i)
                    {
                        if (green[i][j])
                        {
                            int putY = i;
                            for (int k = i + 1; k < 6; ++k)
                            {
                                if (green[k][j])
                                    break;
                                putY = k;
                            }

                            green[putY][j] = true;
                            green[i][j] = false;
                        }
                    }
                }
            }

            for (int j = 2; j < 6; j++)
            {
                bool isFull = true;
                for (int i = 0; i < 4; i++)
                {
                    if (!blue[i][j])
                    {
                        isFull = false;
                        break;
                    }
                }

                if (isFull)
                {
                    for (int i = 0; i < 4; i++)
                        blue[i][j] = false;
                    blueCleanCount++;
                }
            }

            // Push
            if (blueCleanCount > 0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 6 - 1 - 1; j >= 0; --j)
                    {
                        if (blue[i][j])
                        {
                            int putX = j;
                            for (int k = j + 1; k < 6; ++k)
                            {
                                if (blue[i][k])
                                    break;
                                putX = k;
                            }

                            blue[i][putX] = true;
                            blue[i][j] = false;
                        }
                    }
                }
            }

            return greenCleanCount + blueCleanCount;
        }

        static bool Shift(bool[][] green, bool[][] blue)
        {
            int greenShiftCount = 0;
            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 4; j++)
                    if (green[i][j])
                    {
                        greenShiftCount++;
                        break;
                    }

            for (int j = 0; j < 4; j++)
                for (int i = 6 - 1; i >= 6 - 4; i--)
                    green[i][j] = green[i - greenShiftCount][j];

            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 4; j++)
                    green[i][j] = false;

            int blueShiftCount = 0;
            for (int j = 0; j < 2; ++j)
                for (int i = 0; i < 4; i++)
                    if (blue[i][j])
                    {
                        blueShiftCount++;
                        break;
                    }

            for (int i = 0; i < 4; i++)
                for (int j = 6 - 1; j >= 6 - 4; j--)
                    blue[i][j] = blue[i ][j - blueShiftCount];

            for (int j = 0; j < 2; ++j)
                for (int i = 0; i < 4; i++)
                    blue[i][j] = false;


            return greenShiftCount + blueShiftCount > 0;
        }
    }
}

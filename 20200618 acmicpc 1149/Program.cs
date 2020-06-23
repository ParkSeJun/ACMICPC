using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200618_acmicpc_1149
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Trim());
            int[] minRGB = new int[3] { 0, 0, 0 };
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ');
                int[] RGB = new int[3] { int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]) };

                if (i == 0)
                {
                    for (int j = 0; j < 3; ++j)
                        minRGB[j] = RGB[j];
                    continue;
                }

                int[] newMinRGB = new int[3];
                for (int j = 0; j < 3; ++j)
                {
                    int min = int.MaxValue;
                    for (int k = 0; k < 3; ++k)
                    {
                        if (j == k)
                            continue;

                        if (minRGB[k] < min)
                            min = minRGB[k];
                    }
                    newMinRGB[j] = min + RGB[j];
                }

                for (int j = 0; j < 3; ++j)
                    minRGB[j] = newMinRGB[j];
            }

            Console.WriteLine(Math.Min(Math.Min(minRGB[0], minRGB[1]), minRGB[2]));
        }
    }
}

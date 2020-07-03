using System;
using System.Collections.Generic;
using System.Linq;

namespace _20200703_14891
{
    class Program
    {
        public class Gear
        {
            int[] n;

            public Gear(int[] n)
            {
                this.n = n;
            }

            public int GetTop()
            {
                return n[0];
            }

            public int GetLeft()
            {
                return n[6];
            }

            public int GetRight()
            {
                return n[2];
            }

            public void Rotate(bool isClockwise)
            {
                int t = n[0];
                if (isClockwise)
                {
                    n[0] = n[7];
                    n[7] = n[6];
                    n[6] = n[5];
                    n[5] = n[4];
                    n[4] = n[3];
                    n[3] = n[2];
                    n[2] = n[1];
                    n[1] = t;
                }
                else
                {
                    n[0] = n[1];
                    n[1] = n[2];
                    n[2] = n[3];
                    n[3] = n[4];
                    n[4] = n[5];
                    n[5] = n[6];
                    n[6] = n[7];
                    n[7] = t;
                }
            }

            public override string ToString()
            {
                return string.Join("", n);
            }
        }


        static void Main(string[] args)
        {
            List<Gear> gearList = new List<Gear>();
            for (int i = 0; i < 4; i++)
            {
                var row = Console.ReadLine().Select(e => int.Parse(e.ToString())).ToArray();
                gearList.Add(new Gear(row));
            }

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int gearIndex = row[0] - 1;
                bool isClockwise = row[1] > 0;
                List<int> affectGearList = new List<int>();
                affectGearList.Add(gearIndex);

                for (int j = gearIndex - 1; j >= 0; j--)
                {
                    int a = gearList[j].GetRight();
                    int b = gearList[j+1].GetLeft();
                    if (a == b)
                        break;
                    affectGearList.Add(j);
                }

                for (int j = gearIndex + 1; j < gearList.Count; j++)
                {
                    int a = gearList[j].GetLeft();
                    int b = gearList[j-1].GetRight();
                    if (a == b)
                        break;
                    affectGearList.Add(j);
                }

                foreach (var index in affectGearList)
                {
                    gearList[index].Rotate(index % 2 == gearIndex % 2 ? isClockwise : !isClockwise);
                }
            }

            Console.WriteLine(gearList[0].GetTop() + gearList[1].GetTop() * 2 + gearList[2].GetTop() * 4 + gearList[3].GetTop() * 8);
        }
    }
}

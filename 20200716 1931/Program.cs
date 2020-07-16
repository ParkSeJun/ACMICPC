using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200716_1931
{
    class Program
    {
        public struct Schedule
        {
            public int start;
            public int end;

            public Schedule(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        static void Main(string[] args)
        {
            List<Schedule> timeTable = new List<Schedule>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                timeTable.Add(new Schedule(row[0], row[1]));
            }
            timeTable.Sort((a, b) => a.end == b.end ? a.start - b.start : a.end - b.end);

            int curTime = 0;
            int confCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (timeTable[i].start >= curTime)
                {
                    curTime = timeTable[i].end;
                    confCount++;
                }
            }

            Console.WriteLine(confCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200702_13458
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> testerCount = new List<int>();
            var testers = Console.ReadLine().Split(' ');
            for (int i = 0; i < count; i++)
            {
                testerCount.Add(int.Parse(testers[i]));
            }
            var viewers = Console.ReadLine().Split(' ');
            int mainViewCount = int.Parse(viewers[0]);
            int subViewCount = int.Parse(viewers[1]);
        }
    }
}

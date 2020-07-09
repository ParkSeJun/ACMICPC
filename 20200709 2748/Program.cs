using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200709_2748
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = 0;
            long b = 1;
            int count = int.Parse(Console.ReadLine());

            if (count == 1)
            {
                Console.WriteLine(1);
                return;
            }

            for (int i = 0; i < count - 1; i++)
            {
                long t = b;
                b += a;
                a = t;
            }
            Console.WriteLine(b);
        }
    }
}

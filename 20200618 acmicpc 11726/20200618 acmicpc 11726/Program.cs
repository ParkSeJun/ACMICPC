﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200618_acmicpc_11726
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(1));
            Console.WriteLine(Solve(2));
            Console.WriteLine(Solve(3));
            Console.WriteLine(Solve(4));
        }

        public static int Solve(int n)
        {
            if (n < 0)
                return 0;
            if (n <= 1)
                return 1;

            return Solve(n - 1) + Solve(n - 2);
        }
    }
}

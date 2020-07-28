using System;
using System.Collections.Generic;
using System.Linq;

namespace _20200728_10773
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (n == 0)
                    stack.Pop();
                else
                    stack.Push(n);
            }

            Console.WriteLine(stack.Sum());
        }
    }
}

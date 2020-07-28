using System;
using System.Collections.Generic;
using System.Text;

namespace _20200728_1874
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            StringBuilder sb = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            int n = 1;
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                while (n <= input)
                {
                    stack.Push(n++);
                    sb.AppendLine("+");
                }

                if (stack.Peek() != input)
                {
                    Console.WriteLine("NO");
                    return;
                }
                stack.Pop();
                sb.AppendLine("-");
            }
            if (stack.Count > 0)
                Console.WriteLine("NO");
            else
                Console.WriteLine(sb.ToString());

        }
    }
}

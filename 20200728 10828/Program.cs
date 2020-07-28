using System;
using System.Collections.Generic;
using System.Text;

namespace _20200728_10828
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int count = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine();
                if (row.StartsWith("pu"))
                {
                    int n = int.Parse(row.Split(' ')[1]);
                    stack.Push(n);
                }
                else if (row.StartsWith("po"))
                {
                    sb.AppendLine((stack.Count == 0 ? -1 : stack.Pop()).ToString());
                }
                else if (row.StartsWith("s"))
                {
                    sb.AppendLine(stack.Count.ToString());
                }
                else if (row.StartsWith("e"))
                {
                    sb.AppendLine(stack.Count == 0 ? "1" : "0");
                }
                else if (row.StartsWith("t"))
                {
                    sb.AppendLine((stack.Count == 0 ? -1 : stack.Peek()).ToString());
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _20200728_4949
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var row = Console.ReadLine();
                if (row.Equals("."))
                    break;

                try
                {
                    for (int j = 0; j < row.Length; j++)
                    {
                        switch (row[j])
                        {
                            case '(':
                            case '[':
                                stack.Push(row[j]);
                                break;
                            case ')':
                                if (stack.Count == 0 || stack.Pop() != '(')
                                    throw null;
                                break;
                            case ']':
                                if (stack.Count == 0 || stack.Pop() != '[')
                                    throw null;
                                break;
                        }
                    }
                    if (stack.Count != 0)
                        throw null;

                    sb.AppendLine("yes");
                }
                catch
                {
                    sb.AppendLine("no");
                }

                stack.Clear();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}

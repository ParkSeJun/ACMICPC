using System;

namespace _20200728_9012
{
    class Program
    {
        static void Main(string[] args)
        {
            int stack = 0;
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine();
                stack = 0;
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == '(')
                        stack++;
                    else if (row[j] == ')')
                    {
                        stack--;
                        if (stack < 0)
                            break;
                    }
                }
                if (stack == 0)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}

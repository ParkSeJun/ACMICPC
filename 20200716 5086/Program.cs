using System;

namespace _20200716_5086
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                int a = row[0];
                int b = row[1];

                if (a == 0 && b == 0)
                    break;

                if (a < b && b % a == 0)
                    Console.WriteLine("factor");
                else if (b < a && a % b == 0)
                    Console.WriteLine("multiple");
                else
                    Console.WriteLine("neither");
            }
        }
    }
}

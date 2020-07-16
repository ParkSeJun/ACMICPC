using System;
using System.Linq;

namespace _20200716_1541
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Console.ReadLine().Replace("+", " ").Replace("-", " -").Split(' ').Select(e => int.Parse(e)).ToList();

            int sum = 0;
            bool meetNegative = false;
            for (int i = 0; i < row.Count; i++)
            {
                if (meetNegative)
                    sum -= Math.Abs(row[i]);
                else
                {
                    sum += row[i];
                    if (row[i] < 0)
                        meetNegative = true;
                }
            }

            Console.WriteLine(sum);
        }
    }
}

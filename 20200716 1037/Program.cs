using System;
using System.Linq;

namespace _20200716_1037
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e)).ToList();
            row.Sort();
            int answer = (count & 1) == 1 ? row[count / 2] * row[count / 2] : row[0] * row[count - 1];
            Console.WriteLine(answer);
        }
    }
}

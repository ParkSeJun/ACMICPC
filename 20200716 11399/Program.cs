using System;
using System.Linq;

/*
5
3 1 4 3 2
32
*/

namespace _20200716_11399
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(e=>int.Parse(e)).ToList();
            arr.Sort();

            int acc = 0;
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
                acc += sum;
            }
            Console.WriteLine(acc);
        }
    }
}

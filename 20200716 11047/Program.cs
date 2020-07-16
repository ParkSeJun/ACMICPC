using System;

/*
10 4200
1
5
10
50
100
500
1000
5000
10000
50000
*/

namespace _20200716_11047
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            int count = row[0];
            int dest = row[1];
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int cur = dest;
            int coinCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (cur >= arr[count - 1 - i])
                {
                    int div = cur / arr[count - 1 - i];
                    coinCount += div;
                    cur -= arr[count - 1 - i] * div;
                }
            }

            Console.WriteLine(coinCount);
        }
    }
}

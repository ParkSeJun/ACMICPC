using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _20200709_9663
{
    class Program
    {
        static int count = 0;
        static int[] arr;
        static int index;
        static int n;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            //n = 15;

            arr = new int[n];
            index = 0;

            Solve();
            Console.WriteLine(count);
        }

        static void Solve()
        {
            if (index == n)
            {
                count++;
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (!IsValid(j))
                    continue;

                arr[index++] = j;
                Solve();
                index--;
            }
        }

        static bool IsValid(int x)
        {
            for (int i = 0; i < index; ++i)
            {
                if (arr[i] == x)
                    return false;

                if (index - i == Math.Abs(arr[i] - x))
                    return false;
            }
            return true;
        }
    }
}

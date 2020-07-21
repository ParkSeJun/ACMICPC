using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
9
0 0 0 1 1 1 -1 -1 -1
0 0 0 1 1 1 -1 -1 -1
0 0 0 1 1 1 -1 -1 -1
1 1 1 0 0 0 0 0 0
1 1 1 0 0 0 0 0 0
1 1 1 0 0 0 0 0 0
0 1 -1 0 1 -1 0 1 -1
0 -1 1 0 1 -1 0 1 -1
0 1 -1 1 0 -1 0 1 -1

10
12
11
*/

namespace _20200721_1780
{
    class Program
    {
        class Node
        {
            public int size;
            public int y, x;
            Node[] link;

            public Node(int size, int  y, int x)
            {
                this.size = size;
                this.y = y;
                this.x = x;
                link = new Node[9];
            }
        }

        static int[][] arr;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            arr = new int[count][];
            for (int i = 0; i < count; i++)
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;

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
            public Node[] link;

            public bool HasChild => link != null;
            public int Color => arr[y][x];

            public Node(int size, int y, int x)
            {
                this.size = size;
                this.y = y;
                this.x = x;
            }
        }

        static int[][] arr;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            arr = new int[count][];
            for (int i = 0; i < count; i++)
            {
                arr[i] = new int[count];
                var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                for (int j = 0; j < count; j++)
                    arr[i][j] = row[j];
            }

            //var rand = new Random();
            //int count = (int)Math.Pow(3, 7);
            //arr = new int[count][];
            //for (int i = 0; i < count; i++)
            //{
            //    arr[i] = new int[count];
            //    for (int j = 0; j < count; j++)
            //        arr[i][j] = j % 3 - 1;
            //}


            Node head = new Node(count, 0, 0);

            int a = 0;
            int b = 0;
            int c = 0;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(head);
            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                if (IsOneColor(node))
                {
                    switch (node.Color)
                    {
                        case -1:
                            a++;
                            break;
                        case 0:
                            b++;
                            break;
                        case 1:
                            c++;
                            break;
                    }
                    continue;
                }

                node.link = new Node[9];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        node.link[i * 3 + j] = new Node(node.size / 3, node.y + (node.size / 3) * i, node.x + (node.size / 3) * j);
                        stack.Push(node.link[i * 3 + j]);
                    }
                }
            }

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        static bool IsOneColor(Node node)
        {
            int color = arr[node.y][node.x];
            for (int i = 0; i < node.size; i++)
                for (int j = 0; j < node.size; j++)
                    if (arr[node.y + i][node.x + j] != color)
                        return false;
            return true;
        }
    }
}

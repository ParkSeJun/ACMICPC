using System;
using System.Collections.Generic;

/*
8
1 1 0 0 0 0 1 1
1 1 0 0 0 0 1 1
0 0 0 0 1 1 0 0
0 0 0 0 1 1 0 0
1 0 0 0 1 1 1 1
0 1 0 0 1 1 1 1
0 0 1 1 1 1 1 1
0 0 1 1 1 1 1 1

9
7
*/


namespace _20200721_2630
{
    class Program
    {
        public class Pos
        {
            public int y, x;

            public Pos(int y, int x)
            {
                this.y = y;
                this.x = x;
            }
        }

        public class Node
        {
            public int size;
            public Pos p;

            public Node[] link;

            public Node(int size, Pos p)
            {
                this.size = size;
                this.p = p;
                link = new Node[4];
            }

            public Node(int size, int y, int x) : this(size, new Pos(y, x))
            {
            }
        }

        static Node head;
        static int[][] arr;


        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            arr = new int[size][];
            for (int i = 0; i < size; i++)
            {
                arr[i] = new int[size];
                var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                for (int j = 0; j < size; j++)
                    arr[i][j] = row[j];
            }
            head = new Node(size, 0, 0);


            Queue<Node> q = new Queue<Node>();
            q.Enqueue(head);

            while (q.Count > 0)
            {
                Node thisNode = q.Dequeue();
                if (IsOneColor(thisNode))
                    continue;

                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        thisNode.link[i * 2 + j] = new Node(thisNode.size / 2, thisNode.p.y + (thisNode.size / 2) * i, thisNode.p.x + (thisNode.size / 2) * j);

                for (int i = 0; i < 4; i++)
                {
                    if (thisNode.link[i] == null)
                        continue;

                    q.Enqueue(thisNode.link[i]);
                }
            }

            var ret = GetCount(head);
            Console.WriteLine($"{ret.Key}\n{ret.Value}");
        }

        static KeyValuePair<int, int> GetCount(Node node)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            int count0 = 0;
            int count1 = 0;

            while (q.Count > 0)
            {
                Node thisNode = q.Dequeue();

                if (thisNode.link[0] == null)
                {
                    if (arr[thisNode.p.y][thisNode.p.x] == 0)
                        count0++;
                    else
                        count1++;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (thisNode.link[i] == null)
                        continue;
                    q.Enqueue(thisNode.link[i]);
                }
            }

            return new KeyValuePair<int, int>(count0, count1);
        }

        static bool IsOneColor(Node node)
        {
            int color = arr[node.p.y][node.p.x];
            for (int i = 0; i < node.size; i++)
                for (int j = 0; j < node.size; j++)
                    if (arr[node.p.y + i][node.p.x + j] != color)
                        return false;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

/*
8
11110000
11110000
00011100
00011100
11110000
11110000
11110011
11110011

((110(0101))(0010)1(0001)) 
*/

namespace _20200721_1992
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

            public override string ToString()
            {
                if (link[0] == null)
                    return arr[p.y][p.x].ToString();

                StringBuilder sb = new StringBuilder();
                sb.Append("(");
                for (int i = 0; i < 4; i++)
                    sb.Append(link[i].ToString());
                sb.Append(")");
                return sb.ToString();
            }
        }

        static Node head;
        static int[][] arr;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            arr = new int[count][];
            for (int i = 0; i < count; i++)
            {
                arr[i] = new int[count];
                var row = Console.ReadLine();
                for (int j = 0; j < count; j++)
                    arr[i][j] = row[j] -'0';
            }

            head = new Node(count, 0, 0);

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(head);

            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                if (IsOneColor(node))
                    continue;

                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        node.link[i * 2 + j] = new Node(node.size / 2, node.p.y + (node.size / 2) * i, node.p.x + (node.size / 2) * j);
                for (int i = 0; i < 4; i++)
                    q.Enqueue(node.link[i]);
            }

            Console.WriteLine(head);

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

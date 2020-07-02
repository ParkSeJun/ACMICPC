using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200702_14500
{
    class Program
    {
        public class Shape
        {
            public byte[][] shape;
            public int h, w;

            public Shape(int h, int w, byte[][] shape)
            {
                this.h = h;
                this.w = w;
                this.shape = shape;
            }
        }

        static List<Shape> shapeList = new List<Shape>();

        static void Main(string[] args)
        {
            shapeList.Add(new Shape(1, 4, new byte[][] { new byte[] { 1, 1, 1, 1 } }));
            shapeList.Add(new Shape(4, 1, new byte[][] { new byte[] { 1 },
                                                        new byte[] { 1 },
                                                        new byte[] { 1 },
                                                        new byte[] { 1 }}));
            shapeList.Add(new Shape(2, 2, new byte[][] { new byte[] { 1, 1 },
                                                        new byte[] { 1, 1 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 1, 1, 0 },
                                                        new byte[] { 0, 1, 1 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 0, 1, 1 },
                                                        new byte[] { 1, 1, 0 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 0, 1 },
                                                        new byte[] { 1, 1 },
                                                        new byte[] { 1, 0 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 1, 0 },
                                                        new byte[] { 1, 1 },
                                                        new byte[] { 0, 1 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 1, 1, 1 },
                                                        new byte[] { 0, 1, 0 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 0, 1, 0 },
                                                        new byte[] { 1, 1, 1 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 1, 0 },
                                                        new byte[] { 1, 1 },
                                                        new byte[] { 1, 0 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 0, 1 },
                                                        new byte[] { 1, 1 },
                                                        new byte[] { 0, 1 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 1, 1, 1 },
                                                        new byte[] { 1, 0, 0 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 1, 1, 1 },
                                                        new byte[] { 0, 0, 1 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 1, 0, 0 },
                                                        new byte[] { 1, 1, 1 }}));
            shapeList.Add(new Shape(2, 3, new byte[][] { new byte[] { 0, 0, 1 },
                                                        new byte[] { 1, 1, 1 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 1, 1 },
                                                        new byte[] { 1, 0 },
                                                        new byte[] { 1, 0 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 1, 0 },
                                                        new byte[] { 1, 0 },
                                                        new byte[] { 1, 1 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 1, 1 },
                                                        new byte[] { 0, 1 },
                                                        new byte[] { 0, 1 }}));
            shapeList.Add(new Shape(3, 2, new byte[][] { new byte[] { 0, 1 },
                                                        new byte[] { 0, 1 },
                                                        new byte[] { 1, 1 }}));

            int[][] arr;
            var row = Console.ReadLine().Split(' ');
            int h = int.Parse(row[0]);
            int w = int.Parse(row[1]);
            arr = new int[h][];
            for (int i = 0; i < h; i++)
            {
                row = Console.ReadLine().Split(' ');
                arr[i] = new int[w];
                for (int j = 0; j < w; j++)
                    arr[i][j] = int.Parse(row[j]);
            }

            int max = 0;
            foreach (var shape in shapeList)
            {
                for (int i = 0; i <= h - shape.h; i++)
                {
                    for (int j = 0; j <= w - shape.w; j++)
                    {
                        int sum = 0;
                        for (int y = 0; y < shape.h; y++)
                        {
                            for (int x = 0; x < shape.w; x++)
                            {
                                if (shape.shape[y][x] == 1)
                                    sum += arr[i + y][j + x];
                            }
                        }
                        if (max < sum)
                            max = sum;
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}

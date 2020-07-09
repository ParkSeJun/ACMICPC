using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
0 3 5 4 6 N 2 7 8
7 8 2 1 0 5 6 0 N
0 6 0 2 7 8 1 3 5
3 2 1 0 4 6 8 N 7
8 0 4 N 1 3 5 0 6
5 N 6 8 2 0 4 1 3
N 1 7 6 5 2 0 8 0
6 0 3 7 0 1 N 5 2
2 5 8 3 N 4 7 6 0

1 3 5 4 6 N 2 7 8
7 8 2 1 3 5 6 4 N
4 6 N 2 7 8 1 3 5
3 2 1 5 4 6 8 N 7
8 7 4 N 1 3 5 2 6
5 N 6 8 2 7 4 1 3
N 1 7 6 5 2 3 8 4
6 4 3 7 8 1 N 5 2
2 5 8 3 N 4 7 6 1
*/

namespace _2020070N_2580
{
    class Program
    {
        static int N = 9;
        static List<int> l;
        static int[][] arr;
        static Dictionary<int, List<int>> availables;
        static Dictionary<int, List<int>> relationMap;
        static int[] trace;

        static void Main(string[] args)
        {
            l = new List<int>();
            availables = new Dictionary<int, List<int>>();
            relationMap = new Dictionary<int, List<int>>();

            arr = new int[N][];
            for (int i = 0; i < N; i++)
            {
                arr[i] = new int[N];
                var row = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    int t = int.Parse(row[j]);
                    arr[i][j] = t;
                    if (t == 0)
                        l.Add(i * 10 + j);
                }
            }

            bool[] availableArr = new bool[10];
            for (int i = 0; i < l.Count; i++)
            {
                int thisY = l[i] / 10;
                int thisX = l[i] % 10;

                for (int j = 1; j <= N; j++)
                    availableArr[j] = true;

                relationMap[l[i]] = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    int horizontal = arr[thisY][j];
                    availableArr[horizontal] = false;
                    if (horizontal == 0 && thisX != j)
                        relationMap[l[i]].Add(thisY * 10 + j);
                    int vertical = arr[j][thisX];
                    availableArr[vertical] = false;
                    if (vertical == 0 && thisY != j)
                        relationMap[l[i]].Add(j * 10 + thisX);
                }

                int areaY = thisY / 3;
                int areaX = thisX / 3;
                for (int j = 0; j < 3; j++)
                {
                    int thisY_ = areaY * 3 + j;
                    if (thisY_ == thisY)
                        continue;
                    for (int k = 0; k < 3; k++)
                    {
                        int thisX_ = areaX * 3 + k;
                        if (thisX_ == thisX)
                            continue;

                        int around = arr[thisY_][thisX_];
                        availableArr[around] = false;
                        if (around == 0 && thisY_ != thisY && thisX_ != thisX)
                            relationMap[l[i]].Add(thisY_ * 10 + thisX_);
                    }
                }

                availables[l[i]] = new List<int>();
                for (int j = 1; j <= N; j++)
                    if (availableArr[j])
                        availables[l[i]].Add(j);
            }
            trace = new int[l.Count];
            for (int i = 0; i < l.Count; i++)
                trace[i] = 0;
            Solve(0);
        }

        static bool Solve(int index)
        {
            if (index == l.Count)
            {
                Display();
                return true;
            }
            int thisPos = l[index];

            bool isDirty = false;
            List<int> availableNs = null;
            for (int i = 0; i < relationMap[thisPos].Count; i++)
            {
                int relationIdx = l.IndexOf(relationMap[thisPos][i]);
                if (relationIdx < index && (isDirty ? availableNs : availables[thisPos]).Contains(trace[relationIdx]))
                {
                    if (!isDirty)
                    {
                        isDirty = true;
                        availableNs = new List<int>(availables[thisPos]);
                    }
                    availableNs.Remove(trace[l.IndexOf(relationMap[thisPos][i])]);
                }
            }
            //Console.WriteLine($"{string.Join(" ", trace)}");
            //Console.WriteLine($"{index}번째 {string.Join(" ", availables[thisPos])} -> {string.Join(" ", availableNs)}");
            if (!isDirty)
            {
                for (int i = 0; i < availables[thisPos].Count; i++)
                {
                    trace[index] = availables[thisPos][i];
                    if (Solve(index + 1))
                        return true;
                }
                return false;
            }
            for (int i = 0; i < availableNs.Count; i++)
            {
                trace[index] = availableNs[i];
                if (Solve(index + 1))
                    return true;
            }
            return false;
        }

        static void Display()
        {
            int traceIndex = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    sb.Append($"{(arr[i][j] == 0 ? trace[traceIndex++] : arr[i][j])} ");
                //Console.Write($"{(arr[i][j] == 0 ? trace[traceIndex++] : arr[i][j])} ");
                sb.AppendLine();
                //Console.WriteLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

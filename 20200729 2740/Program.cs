using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _20200729_2740
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, k;
            int[][] arr1;
            int[][] arr2;

            var row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            n = row[0];
            m = row[1];

            arr1 = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr1[i] = new int[m];
                row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                for (int j = 0; j < m; j++)
                    arr1[i][j] = row[j];
            }

            row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
            m = row[0];
            k = row[1];

            arr2 = new int[m][];
            for (int i = 0; i < m; i++)
            {
                arr2[i] = new int[k];
                row = Array.ConvertAll(Console.ReadLine().Split(' '), e => int.Parse(e));
                for (int j = 0; j < k; j++)
                    arr2[i][j] = row[j];
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    int sum = 0;
                    for (int a = 0; a < m; a++)
                        sum += arr1[i][a] * arr2[a][j];
                    sb.Append(sum.ToString());
                    sb.Append(" ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

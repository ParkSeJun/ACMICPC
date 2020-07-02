using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200702_14501
{
    class Program
    {
        public class Data
        {
            public int days;
            public int pay;
            public Data(int days, int pay)
            {
                this.days = days;
                this.pay = pay;
            }
        }

        static List<Data> datas = new List<Data>();
        static Dictionary<int, int> dic = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Split(' ');
                datas.Add(new Data(int.Parse(row[0]), int.Parse(row[1])));
            }

            var a = Solve(0);
            Console.WriteLine(a);
        }

        static int Solve(int index)
        {
            if (index >= datas.Count)
                return 0;

            if (!dic.ContainsKey(index))
            {
                int skip = Solve(index + 1);
                int work = 0;
                if (index + datas[index].days <= datas.Count)
                    work = Solve(index + datas[index].days) + datas[index].pay;

                dic[index] = Math.Max(skip, work);
            }

            return dic[index];
        }
    }
}

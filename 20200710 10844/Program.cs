using System;
using System.Collections.Generic;

namespace _20200710_10844
{
    class Program
    {
        static int MOD = 1000000000;
        static Dictionary<int, int> defaultDic = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            for (int i = 0; i <= 9; i++)
                defaultDic[i] = 0;

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(GetSum(GetArr(i + 1)));
            //}

            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSum(GetArr(n)));
        }

        static Dictionary<int, int> GetArr(int n)
        {
            if (n == 1)
            {
                var ret = new Dictionary<int, int>();
                ret[0] = 0;
                for (int i = 1; i <= 9; i++)
                    ret[i] = 1;
                return ret;
            }

            var dic = GetArr(n - 1);
            var clone = new Dictionary<int, int>(defaultDic);
            clone[1] = (clone[1] + dic[0]) % MOD;
            clone[8] = (clone[8] + dic[9]) % MOD;
            for (int i = 1; i < 9; i++)
            {
                clone[i - 1] = (clone[i - 1] + dic[i]) % MOD;
                clone[i + 1] = (clone[i + 1] + dic[i]) % MOD;
            }

            return clone;
        }

        static int GetSum(Dictionary<int, int> dic)
        {
            int sum = 0;
            for (int i = 0; i <= 9; i++)
                sum = (sum + dic[i]) % MOD;
            return sum;
        }
    }
}

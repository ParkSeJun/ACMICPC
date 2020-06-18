using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20200108_acmicpc_15953
{
    /*
6
8 4
13 19
8 10
18 18
8 25
13 16
         */
    class Program
    {
        static void Main(string[] args)
        {
            new Game();
        }
    }

    class Game
    {
        public Game()
        {
            List<(int f, int s)> inputs = new List<(int f, int s)>();
            int inputCount = ReadInput()[0];
            for (int i = 0; i < inputCount; ++i)
            {
                var input = ReadInput();
                int first = input[0];
                int second = input[1];

                inputs.Add((first, second));
            }

            foreach (var input in inputs)
            {
                int sum = 0;
                sum += GetRewardFirst(input.f);
                sum += GetRewardSecond(input.s);
                Console.WriteLine($"{sum}{(sum > 0 ? "0000" : "")}");
            }

        }

        int GetRewardFirst(int rank)
        {
            if (rank == 0)
                return 0;

            int[] countPerRank = { 1, 2, 3, 4, 5, 6 };
            int[] rewardPerRank = { 500, 300, 200, 50, 30, 10 };

            int acRank = 0;
            for (int i = 0; i < countPerRank.Length; ++i)
            {
                acRank += countPerRank[i];
                if (rank <= acRank)
                    return rewardPerRank[i];
            }
            return 0;
        }

        int GetRewardSecond(int rank)
        {
            if (rank == 0)
                return 0;

            int[] countPerRank = { 1, 2, 4, 8, 16 };
            int[] rewardPerRank = { 512, 256, 128, 64, 32 };

            int acRank = 0;
            for (int i = 0; i < countPerRank.Length; ++i)
            {
                acRank += countPerRank[i];
                if (rank <= acRank)
                    return rewardPerRank[i];
            }
            return 0;
        }

        int[] ReadInput()
        {
            return ReadInput(Console.ReadLine());
        }

        int[] ReadInput(string line)
        {
            Regex regex = new Regex(@"(\d+)");
            if (!regex.IsMatch(line))
                return null;

            List<int> ret = new List<int>();
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                if (!int.TryParse(match.Value, out int v))
                    continue;
                ret.Add(v);
            }

            return ret.ToArray();
        }
    }
}

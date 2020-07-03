using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200703_14889
{
    class Program
    {
        static int[][] arr;
        static int count;

        static void Main(string[] args)
        {
            count = int.Parse(Console.ReadLine());
            arr = new int[count][];
            for (int i = 0; i < count; i++)
            {
                var row = Console.ReadLine().Split().Select((e) => int.Parse(e)).ToList();
                arr[i] = new int[count];
                for (int j = 0; j < count; j++)
                    arr[i][j] = row[j];
            }

            var availableTeamList = GetAvailableTeam(count);
            int minDiff = int.MaxValue;
            foreach (var team in availableTeamList)
            {
                List<int> otherTeam = Enumerable.Range(0, count).Except(team).ToList();

                int powerA = GetTeamPower(team);
                int powerB = GetTeamPower(otherTeam);
                //Console.WriteLine(string.Join("", team) + " " + powerA.ToString() + " vs " + string.Join("", otherTeam) + " " + powerB.ToString());


                int diff = Math.Abs(powerA - powerB);

                if (minDiff > diff)
                {
                    //Console.WriteLine(string.Join("", team) + " " +  powerA);
                    //Console.WriteLine(string.Join("", otherTeam) + " " + powerB);
                    //Console.WriteLine();
                    minDiff = diff;
                }
            }

            Console.WriteLine(minDiff);
        }

        static int GetTeamPower(List<int> team)
        {
            int sum = 0;
            for (int i = 0; i < team.Count; i++)
            {
                for (int j = 0; j < team.Count; j++)
                {
                    sum += arr[team[i]][team[j]];
                }
            }
            return sum;
        }

        static List<List<int>> GetAvailableTeam(int n)
        {
            List<List<int>> ret = new List<List<int>>();

            Recur(ret, n);

            return ret;

            
        }
        static void Recur(List<List<int>> ret, int n, List<int> pick = null, int index = -1)
        {
            if (pick == null)
                pick = new List<int>();
            else
                pick = (from e in pick select e).ToList();

            if (index >= 0)
                pick.Add(index);

            if (pick.Count == n / 2)
            {
                ret.Add(pick);
                return;
            }

            for (int i = index + 1; i < n - (n / 2 - pick.Count - 1); i++)
            {
                Recur(ret, n, pick, i);
            }
        }


    }
}

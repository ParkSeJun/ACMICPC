#include <stdio.h>

int countPerRankFirst[]{ 1,2,3,4,5,6 }; // 1,3,6,10,15,21
int rewardPerRankFirst[]{ 500,300,200,50,30,10 };
int countPerRankSecond[]{ 1, 2, 4, 8, 16 };
int rewardPerRankSecond[]{ 512, 256, 128, 64, 32 };


int GetRewardFirst(int rank)
{
	if (rank == 0)
		return 0;

	int acRank = 0;
	for (int i = 0; i < sizeof(countPerRankFirst) / sizeof(int); ++i)
	{
		acRank += countPerRankFirst[i];
		if (rank <= acRank)
			return rewardPerRankFirst[i];
	}
	return 0;
}
int GetRewardSecond(int rank)
{
	if (rank == 0)
		return 0;

	int acRank = 0;
	for (int i = 0; i < sizeof(countPerRankSecond) / sizeof(int); ++i)
	{
		acRank += countPerRankSecond[i];
		if (rank <= acRank)
			return rewardPerRankSecond[i];
	}
	return 0;
}

int main()
{
	int n;
	scanf("%d", &n);
	for (int i = 0; i < n; ++i)
	{
		int a, b;
		scanf("%d%d", &a, &b);

		int sum = GetRewardFirst(a) + GetRewardSecond(b);
		printf("%d%s\n", sum, sum > 0 ? "0000" : "");
	}

	return 0;
}
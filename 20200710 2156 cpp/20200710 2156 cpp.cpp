#include <stdio.h>
#include <map>
#include <algorithm>
using namespace std;

map<pair<int, int>, int> table;
int* arr;
int glassCount;

int Solve(int index, int stepCount)
{
	if (index >= glassCount)
		return 0;
	if (stepCount >= 2)
		return 0;

	pair<int, int> p = make_pair(index, stepCount);
	if (table.find(p) == table.end())
	{
		int max = Solve(index + 1, stepCount + 1);
		for (size_t i = 2; i < glassCount - index; i++)
		{
			int t = Solve(index + i, 0);
			if (max < t)
				max = t;
		}
		table[p] = max + (index >= 0 ? arr[index] : 0);
	}

	return table[p];
}

int main()
{
	//scanf("%d", &glassCount);
	glassCount = 10000;
	arr = new int[glassCount];
	for (size_t i = 0; i < glassCount; i++)
		/*scanf("%d", &arr[i]);*/
		arr[i] = rand() % 1000 + 1;

	int ret = Solve(-1, -1);
	printf("%d", ret);

	return 0;
}
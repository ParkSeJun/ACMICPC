#include <stdio.h>
#include <vector>
#include <map>
#include <algorithm>
using namespace std;

vector<int> l;
int arr[9][9];
map<int, vector<int>> availables;
map<int, vector<int>> relationMap;
int* trace;

void Display();
bool Solve(size_t index);

int main()
{
	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			scanf("%d", &arr[i][j]);
			if (arr[i][j] == 0)
				l.push_back(i * 10 + j);
		}
	}

	bool availableArr[10];
	for (size_t i = 0; i < l.size(); i++)
	{
		int thisY = l[i] / 10;
		int thisX = l[i] % 10;
		for (int j = 0; j <= 9; j++)
			availableArr[j] = true;

		for (int j = 0; j < 9; j++)
		{
			int horizontal = arr[thisY][j];
			availableArr[horizontal] = false;
			if (horizontal == 0 && j != thisX)
				relationMap[l[i]].push_back(thisY * 10 + j);

			int vertical = arr[j][thisX];
			availableArr[vertical] = false;
			if (vertical == 0 && j != thisY)
				relationMap[l[i]].push_back(j * 10 + thisX);
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

				availableArr[arr[thisY_][thisX_]] = false;
				if (arr[thisY_][thisX_] == 0)
					relationMap[l[i]].push_back(thisY_ * 10 + thisX_);
			}
		}

		for (int j = 1; j <= 9; j++)
			if (availableArr[j])
				availables[l[i]].push_back(j);
	}

	trace = new int[l.size()];
	for (size_t i = 0; i < l.size(); i++)
		trace[i] = 0;
	Solve(0);

	return 0;
}

bool Solve(size_t index)
{
	if (index == l.size())
	{
		Display();
		return true;
	}

	int thisPos = l[index];

	vector<int> availableNs = vector<int>(availables[thisPos]);
	for (auto it = relationMap[thisPos].begin(); it != relationMap[thisPos].end(); ++it)
	{
		auto f = std::find(l.begin(), l.end(), *it);
		int relationIndex = distance(l.begin(), f);
		if (relationIndex >= index)
			continue;
		f = find(availableNs.begin(), availableNs.end(), trace[relationIndex]);
		if (f != availableNs.end())
			availableNs.erase(f);
	}
	for (int i = 0; i < availableNs.size(); i++)
	{
		trace[index] = availableNs[i];
		if (Solve(index + 1))
			return true;
	}
	return false;
}

void Display()
{
	int traceIndex = 0;
	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			if (arr[i][j] == 0)
				printf("%d ", trace[traceIndex++]);
			else
				printf("%d ", arr[i][j]);
		}
		printf("\n");
	}
}
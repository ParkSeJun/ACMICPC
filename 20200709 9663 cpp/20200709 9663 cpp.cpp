#include <stdio.h>

int count = 0;
int* arr;
int index=0;
int n;

bool IsValid(int x)
{
	for (int i = 0; i < index; i++)
	{
		if (arr[i] == x)
			return false;

		int xDiff = arr[i] - x;
		if (xDiff < 0)
			xDiff = -xDiff;

		if (index - i == xDiff)
			return false;
	}
	return true;
}

void Solve()
{
	if (index == n)
	{
		count++;
		return;
	}

	for (int i = 0; i < n; i++)
	{
		if (!IsValid(i))
			continue;

		arr[index++] = i;
		Solve();
		index--;
	}
}

int main()
{
	scanf("%d", &n);
	arr = new int[n];

	Solve();
	printf("%d", count);

	return 0;
}
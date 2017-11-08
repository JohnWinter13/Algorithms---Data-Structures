#include "stdafx.h"
//A disjoint set implementation permitting quick checks to see if two nodes are in the same set.
const int maxN = 10;
int id[maxN];

void init()
{
	for (int i = 0; i < maxN; i++)
		id[i] = i;
}

int root(int i)
{
	if (id[i] != i)
		return root(id[i]);

	return i;
}

void unite(int i, int j)
{
	id[root(i)] = root(j);
}

bool find(int i, int j)
{
	return root(i) == root(j);
}

#include <iostream>
int main()
{
	init();
	unite(1, 2);
	unite(4, 2);
	unite(3, 5);
	std::cout << find(1, 4) << "\n";
	std::cout << find(1, 3) << "\n";
	std::cout << find(3, 5) << "\n";
	unite(1, 5);
	std::cout << find(1, 3) << "\n";
    return 0;
}

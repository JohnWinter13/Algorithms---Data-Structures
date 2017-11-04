#include "stdafx.h"

const int capacity = 10;

//A binary indexed tree implementation with sum and update operations in O(log(n))

int sum(int BIT[], int index)
{
	index++; //index in BIT is 1 more than index in the original array
	int sum = 0;
	for (int i = index; i > 0; i -= i&-i)
		sum += BIT[i];

	return sum;
}

void update(int BIT[], int index, int delta)
{
	index++;
	for (int i = index; i < capacity + 1; i += i&-i)
		BIT[i] += delta;
}

int* createTree(int arr[])
{
	static int BIT[capacity + 1];
	for (int i = 0; i < capacity; i++)
		update(BIT, i + 1, arr[i]);
	
	return BIT;
}

//returns the sum on the interval [start,end]
int intervalSum(int BIT[], int start, int end)
{
	return sum(BIT, end) - sum(BIT, start - 1);
}

#include <iostream>
int main()
{
	//A test program
	int arr[] = { 5,6,8,15,12,8,3,1,0,10 };
	int* tree = createTree(arr);
	std::cout << intervalSum(tree, 0, 9) << "\n";
	std::cout << intervalSum(tree, 4, 8) << "\n";
	update(tree, 4, 5);
	std::cout << intervalSum(tree, 4, 8) << "\n";
	update(tree, 1, -4);
	update(tree, 7, 15);
	std::cout << intervalSum(tree, 0, 9) << "\n";
    return 0;
}
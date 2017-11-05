#include "stdafx.h"
#include <vector>

const int maxN = 10;
std::vector<int> adjList[maxN];
bool visited[maxN];
bool DFS(int vertex, int sink)
{
	visited[vertex] = true;
	for (int neighbour : adjList[vertex])
		if (!visited[neighbour])
			DFS(neighbour, sink);

	return visited[sink];
}

#include <iostream>
int main()
{
	//A bidirectional graph
	adjList[2].push_back(1);
	adjList[1].push_back(2);
	adjList[5].push_back(2);
	adjList[2].push_back(5);
	adjList[6].push_back(7);
	adjList[7].push_back(6);

	std::cout << DFS(2, 5) << "\n";
	std::memset(visited, false, sizeof visited);
	std::cout << DFS(1, 5) << "\n";
	std::memset(visited, false, sizeof visited);
	std::cout << DFS(1, 7) << "\n";
	std::memset(visited, false, sizeof visited);
	std::cout << DFS(6, 7) << "\n";
    return 0;
}
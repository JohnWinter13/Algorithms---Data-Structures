#include <queue>
#include <vector>

typedef std::pair<int, int> pii;
const int maxN = 6;
std::vector<pii> adjList[maxN];

//returns the shortest path from a source to every other vertex, or 1 << 30 if no path exists
int* dijkstra(int source)
{
    std::priority_queue<pii> pq;
    static int dist[maxN];
    for (int i = 0; i < maxN; i++)
        dist[i] = 1 << 30;
    pq.push(std::make_pair(source, 0));
    dist[source] = 0;

    while (pq.size() > 0) 
    {
        int vertex = pq.top().first;
        pq.pop();
        for (pii neighbour : adjList[vertex])
	{
            int tempCost = dist[vertex] + neighbour.second;
            if (tempCost < dist[neighbour.first])
	    {
                pq.push(std::make_pair(neighbour.first, tempCost));
                dist[neighbour.first] = tempCost;
            }
        }
    }
    return dist;
}

#include <iostream>
int main()
{
    //A bidirectional graph for testing
    adjList[2].push_back(std::make_pair(1, 2));
    adjList[1].push_back(std::make_pair(2, 2));
    adjList[2].push_back(std::make_pair(1, 1));
    adjList[1].push_back(std::make_pair(2, 1));
    adjList[2].push_back(std::make_pair(4, 7));
    adjList[4].push_back(std::make_pair(2, 7));
    adjList[4].push_back(std::make_pair(5, 2));
    adjList[5].push_back(std::make_pair(4, 2));
    adjList[1].push_back(std::make_pair(5, 1));
    adjList[5].push_back(std::make_pair(1, 1));

    int* paths = dijkstra(1);
    for (int i = 1; i < maxN; i++)
        paths[i] == 1 << 30 ? std::cout << -1 << "\n" : std::cout << paths[i] << "\n";

    /*
	Output:
	0 From 1 -> 1, dist is obviously 0
	1 From 1 -> 2, takes the shorter edge(length 1) instead of edge of length 2
	-1 From 1 -> 3, no path to node 3 exists
	3 From 1 -> 4, 1 -> 2 (cost = 1), 2 -> 4 (cost = 7), 1 + 7 = 8 vs 1 -> 5 (cost 1) 5 -> 4 (cost 2), 1 + 2 = 3, 3 < 8
	1 From 1 -> 5, 1 -> 2 (cost = 1), 2 -> 4 (cost = 7), 1 -> 5 (cost = 2), 1 + 7 + 2 = 10 vs 1 -> 5 (cost = 1), 1 < 10
	*/

    return 0;
}


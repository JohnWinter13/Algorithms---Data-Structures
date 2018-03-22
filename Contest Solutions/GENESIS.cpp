#include <bits/stdc++.h>
#include <iostream>
#include <vector>
#include <algorithm>

typedef std::pair<int, int> pii;
const int maxN = 202;
int adjList[maxN][maxN];
bool visited[maxN];
int parent[maxN];

int DFS(int source, int sink)
{
    if (source == sink)
    {
        std::vector<pii> path;
        int min = 1 << 30;
        while (parent[source] != -1)
        {
            path.push_back(std::make_pair(parent[source], source));
            min = std::min(min, adjList[parent[source]][source]);
            source = parent[source];
        }
        for (auto edge : path)
        {
            int capacity = adjList[edge.first][edge.second];
            adjList[edge.first][edge.second] = capacity - min;
            capacity = adjList[edge.second][edge.first];
            adjList[edge.second][edge.first] = capacity + min;
        }
        return min;
    }

    visited[source] = true;
    for (int i = 1; i < maxN; i++)
    {
        if (!visited[i] && adjList[source][i] > 0)
        {
            visited[i] = true;
            parent[i] = source;
            int temp = DFS(i, sink);
            if (temp != -1)
                return temp;
        }
    }
    return -1;
}

// ford fulkerson
int maxFlow(int source, int sink)
{
    int flow = 0;
    int maxflow = 0;
    while (flow != -1)
    {
        maxflow += flow;
        std::memset(visited, false, sizeof visited);
        std::memset(parent, 0, sizeof parent);
        parent[source] = -1;
        flow = DFS(source, sink);
    }
    return maxflow;
}

int main()
{
    int n;
    std::cin >> n;
    for (int i = 0, idx = 0; i < n - 1; i++, idx += 2)
    {
        int a;
        std::cin >> a;
        adjList[idx][idx + 1] = a;
    }
    int m;
    std::cin >> m;
    for (size_t i = 0; i < m; i++)
    {
        int a, b;
        std::cin >> a >> b;
        adjList[a * 2 - 1][(b - 1) * 2] = 1 << 30;
    }
    std::cout << maxFlow(0, (n - 1) * 2);
    return 0;
}
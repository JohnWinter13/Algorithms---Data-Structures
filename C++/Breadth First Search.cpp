#include <vector>
#include <queue>

const int maxN = 10;
std::vector<int> adjList[maxN];

//Returns the shortest path, or -1 if no path exists
int BFS(int source, int sink)
{
    std::queue<int> Q;
    bool visited[maxN] = {};
    visited[source] = true;
    Q.push(source);
    int depth = 0;
    int count = 1; //tracks the number of nodes on each traversal level

    while (Q.size() > 0) {
        count--;
        int vertex = Q.front();
        Q.pop();

        if (vertex == sink)
            return depth;

        for (int neighbour : adjList[vertex]) {
            if (!visited[neighbour]) {
                visited[neighbour] = true;
                Q.push(neighbour);
            }
        }

        if (count == 0) {
            count = Q.size();
            depth++;
        }
    }

    return -1;
}

#include <iostream>
int main()
{
    //A bidirectional graph for testing
    adjList[2].push_back(1);
    adjList[1].push_back(2);
    adjList[5].push_back(2);
    adjList[2].push_back(5);
    adjList[6].push_back(7);
    adjList[7].push_back(6);

    std::cout << BFS(2, 5) << "\n"; //outputs 1, 2 -> 5
    std::cout << BFS(1, 5) << "\n"; //outputs 2, 1 -> 2 -> 5
    std::cout << BFS(1, 7) << "\n"; //outputs -1
    std::cout << BFS(6, 7) << "\n"; //outputs 1, 6 -> 7
    return 0;
}

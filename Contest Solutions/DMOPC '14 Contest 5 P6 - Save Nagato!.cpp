#include <iostream>
#include <vector>
#include <queue>

std::vector<int> adjList[500001];
int dist[500001];
std::pair<int, int> furthest;
void BFS(int source)
{
    std::queue<int> Q;
    Q.push(source);
    bool visited[500001] = {};
    visited[source] = true;
    int depth = 1;
    int counter = Q.size();

    while (Q.size() > 0)
    {
        int vertex = Q.front();
        Q.pop();
        counter--;

        for (int neighbour : adjList[vertex])
        {
            if (!visited[neighbour])
            {
                visited[neighbour] = true;
                Q.push(neighbour);
                dist[neighbour] = std::max(dist[neighbour], depth + 1);
                if (dist[neighbour] > furthest.first)
                    furthest = std::make_pair(dist[neighbour], neighbour);
            }
        }

        if (counter == 0)
        {
            counter = Q.size();
            depth++;
        }
    }
    dist[source] = depth - 1;
}

int main()
{
    std::cin.sync_with_stdio(0);
    std::cin.tie(0);
    int N, A, B;
    std::cin >> N;
    for (size_t i = 0; i < N - 1; i++)
    {
        std::cin >> A >> B;
        adjList[A].push_back(B);
        adjList[B].push_back(A);
    }
    BFS(1);
    BFS(furthest.second);
    BFS(furthest.second);
    for (size_t i = 1; i <= N; i++)
        std::cout << dist[i] << "\n";

    return 0;
}
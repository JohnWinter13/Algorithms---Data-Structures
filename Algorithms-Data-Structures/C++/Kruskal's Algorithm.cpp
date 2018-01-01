//Kruskal's MST algorithm with a disjoint set
#include <algorithm>
#include <vector>
#include <tuple>

const int maxN = 10;
int id[maxN];

void init()
{
    for (int i = 0; i < maxN; i++)
        id[i] = i;
}

int root(int i)
{
    if (i != id[i])
        id[i] = root(id[i]);
    return id[i];
}

void unite(int i, int j)
{
    id[root(i)] = root(j);
}

bool find(int i, int j)
{
    return root(i) == root(j);
}

//Returns the weight of the minimum spanning tree, or -1 if it doesn't exist
int kruskal(std::vector<std::tuple<int, int, int> > edges, int numNodes)
{
    init();
    int connected = 0, weight = 0;
    std::sort(std::begin(edges), std::end(edges));

    for (size_t i = 0; i < edges.size(); i++) 
    {
        int first = std::get<0>(edges[i]), second = std::get<1>(edges[i]);
        if (!find(first, second)) 
	{
            unite(first, second);
            weight += std::get<2>(edges[i]);
            connected++;
        }
    }
    return connected == numNodes - 1 ? weight : -1;
}

#include <iostream>
int main()
{
    std::vector<std::tuple<int, int, int> > edges;
    edges.push_back(std::make_tuple(1, 2, 3));
    edges.push_back(std::make_tuple(1, 2, 1));
    edges.push_back(std::make_tuple(2, 3, 5));
    edges.push_back(std::make_tuple(2, 3, 3));
    edges.push_back(std::make_tuple(1, 4, 7));
    std::cout << kruskal(edges, 4) << "\n"; //outputs 11, 1 + 3 + 7
    return 0;
}


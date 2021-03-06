#include <stack>
using namespace std;

pair<int, int> QU[500001]; // root, size
stack<pair<int, int>> Edges;

void Init(int N)
{
    for (size_t i = 1; i <= N; i++)
        QU[i] = make_pair(i, 1);
}

int Root(int p)
{
    if (QU[p].first != p)
        return Root(QU[p].first);

    return QU[p].first;
}

void AddEdge(int U, int V)
{
    int i = Root(U);
    int j = Root(V);
    Edges.push(make_pair(i, j));

    if (i != j)
    {
        if (QU[i].second < QU[j].second)
        {
            QU[j].second += QU[i].second;
            QU[i].first = j;
        }
        else
        {
            QU[i].second += QU[j].second;
            QU[j].first = i;
        }
    }
}

void RemoveLastEdge()
{
    auto Edge = Edges.top();
    Edges.pop();
    int i = Edge.first;
    int j = Edge.second;

    if (i != j)
    {
        if (QU[i].second < QU[j].second)
        {
            QU[j].second -= QU[i].second;
            QU[i].first = i;
        }
        else
        {
            QU[i].second -= QU[j].second;
            QU[j].first = j;
        }
    }
}

int GetSize(int U)
{
    return QU[Root(U)].second;
}
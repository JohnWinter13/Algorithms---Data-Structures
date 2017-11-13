using System;
using System.Collections.Generic;

public class SPFA<T>
{
    public Dictionary<T, int> ShortestPaths(WeightedGraph<T> Graph, T Source)
    {
        var Dists = new Dictionary<T, int>();
        foreach (var Vertex in Graph.AdjacencyList)
            Dists[Vertex.Key] = 1 << 30;
        var Q = new Queue<T>();
        Q.Enqueue(Source);
        Dists[Source] = 0;

        while (Q.Count > 0)
        {
            var Vertex = Q.Dequeue();
            foreach (var Neighbour in Graph.AdjacencyList[Vertex])
            {
                int TempDist = Dists[Vertex] + Neighbour.Item2;
                if (TempDist < Dists[Neighbour.Item1])
                {
                    Dists[Neighbour.Item1] = TempDist;
                    Q.Enqueue(Neighbour.Item1);
                }
            }
        }
        return Dists;
    }
}

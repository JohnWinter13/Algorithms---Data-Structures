using System;
using System.Collections.Generic;

public class WeightedGraph<T>
{
    public Dictionary<T, HashSet<Tuple<T, int>>> AdjacencyList { get; } = new Dictionary<T, HashSet<Tuple<T, int>>>();
    public int VertexCount { get; private set; } = 0;

    public void AddVertex(T Vertex)
    {
        AdjacencyList[Vertex] = new HashSet<Tuple<T, int>>();
        VertexCount++;
    }

    public void AddDirectedEdge(T A, T B, int W)
    {
        AdjacencyList[A].Add(Tuple.Create(B, W));
    }

    public void AddBiEdge(T A, T B, int W)
    {
        AdjacencyList[A].Add(Tuple.Create(B, W));
        AdjacencyList[B].Add(Tuple.Create(A, W));
    }

    public void RemoveDirectedEdge(T A, T B, int W)
    {
        AdjacencyList[A].Remove(Tuple.Create(B, W));
    }

    public void RemoveBiEdge(T A, T B, int W)
    {
        AdjacencyList[A].Remove(Tuple.Create(B, W));
        AdjacencyList[B].Remove(Tuple.Create(A, W));
    }
}


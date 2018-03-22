using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Noisy_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>();

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)  
                graph.AddVertex(i + 1);
                  
            int M = int.Parse(Console.ReadLine());
            for (int i = 0; i < M; i++)
            {
                string[] ln = Console.ReadLine().Split();
                graph.AddEdge(Tuple.Create(int.Parse(ln[0]), int.Parse(ln[1])));
            }

            Console.WriteLine(DetectCycle(graph, N) == true ? 'N' : 'Y');
            Console.ReadKey();      
        }

        static bool DetectCycle(Graph<int> graph, int N)
        {
            var White = new HashSet<int>();
            var Gray = new HashSet<int>();
            var Black = new HashSet<int>();
            for (int i = 0; i < N; i++)
                White.Add(i + 1);

            while (White.Count > 0)
            {
                var vertex = White.First();
                if (DFS(graph, White, Gray, Black, vertex))
                    return true;
            }
            return false;
        }

        public static bool DFS<T>(Graph<T> graph, HashSet<T> Unvisited, HashSet<T> Visiting, HashSet<T> Visited, T vertex)
        {
            Unvisited.Remove(vertex);
            Visiting.Add(vertex);

            foreach (var neighbour in graph.AdjacencyList[vertex])
            {
                if (Visiting.Contains(neighbour))
                    return true;

                if (Unvisited.Contains(neighbour))
                {
                    Unvisited.Remove(neighbour);
                    Visiting.Add(neighbour);
                    if (DFS(graph, Unvisited, Visiting, Visited, neighbour))
                        return true;
                }
            }

            Visiting.Remove(vertex);
            Visited.Add(vertex);
            return false;
        }

        public class Graph<T>
        {
            public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

            public void AddVertex(T vertex)
            {
                AdjacencyList[vertex] = new HashSet<T>();
            }

            public void AddEdge(Tuple<T, T> edge)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                    AdjacencyList[edge.Item1].Add(edge.Item2);                
            }
        }
    }
}
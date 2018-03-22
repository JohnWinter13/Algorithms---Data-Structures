using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Hunt
{
    class Program
    {
        static int keys;
        static int treasures;
        static HashSet<Tuple<int, int>> collected;
        static int N;
        static char[,] maze;

        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                N = int.Parse(Console.ReadLine());
                maze = new char[N, N];
                keys = 0;
                treasures = 0;
                collected = new HashSet<Tuple<int, int>>();
                Tuple<int,int> start = null;

                for (int y = 0; y < N; y++)
                {
                    string ln = Console.ReadLine();
                    for (int x = 0; x < N; x++)
                    {
                        maze[x, y] = ln[x];
                        if (ln[x] == 'S')
                            start = Tuple.Create(x, y);
                    }
                }
                BFS(start);
                BFS(start);
                BFS(start);
                Console.WriteLine(treasures);
            }
            Console.ReadKey();
        }

        private static bool CheckEdge (int x, int y)
        {         
            if (maze[x,y] == '#')
                return false;
            if (char.IsNumber(maze[x ,y]))
            {
                int num = int.Parse(maze[x, y].ToString());
                if (keys >= num)
                    return true;

                return false;
            }
            return true;
        }

        private static void BFS(Tuple<int, int> start)
        {
            var visited = new HashSet<Tuple<int ,int>>();
            var queue = new Queue<Tuple<int ,int>>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                int x = vertex.Item1; int y = vertex.Item2;
                if (maze[x, y] == 'T' && !collected.Contains(vertex))
                {
                    treasures++;
                    collected.Add(vertex);
                }

                else if (maze[x, y] == 'K' && !collected.Contains(vertex))
                {
                    keys++;
                    collected.Add(vertex);
                }

                if (CheckEdge(x, y))
                {
                    if (x < N - 1 && CheckEdge(x + 1, y) && !visited.Contains(Tuple.Create(x+1, y)))
                    {
                        queue.Enqueue(Tuple.Create(x + 1, y));
                        visited.Add(Tuple.Create(x + 1, y));
                    }

                    if (x > 0 && CheckEdge(x - 1, y) && !visited.Contains(Tuple.Create(x - 1, y)))
                    {
                        queue.Enqueue(Tuple.Create(x - 1, y));
                        visited.Add(Tuple.Create(x - 1, y));
                    }

                    if (y < N - 1 && CheckEdge(x, y + 1) && !visited.Contains(Tuple.Create(x, y + 1)))
                    {
                        queue.Enqueue(Tuple.Create(x, y + 1));
                        visited.Add(Tuple.Create(x, y + 1));
                    }

                    if (y > 0 && CheckEdge(x, y - 1) && !visited.Contains(Tuple.Create(x, y - 1)))
                    {
                        queue.Enqueue(Tuple.Create(x, y - 1));
                        visited.Add(Tuple.Create(x, y - 1));
                    }
                }
            }
        }
    }
}
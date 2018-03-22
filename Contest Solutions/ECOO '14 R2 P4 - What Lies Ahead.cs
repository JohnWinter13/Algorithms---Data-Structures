using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_Lies_Ahead
{
    class Program
    {
        static char[,] maze;
        static List<Tuple<int, int>> Treasures;
        static bool[] found;
        static Tuple<int, int, int> start;
        static HashSet<Tuple<int, int, int>> visited;
        static Queue<Tuple<int, int, int>> queue;
        static Tuple<int, int, int> vertex;

        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                maze = new char[6, 6];               
                Treasures = new List<Tuple<int, int>>();
                found = new bool[5];
                for (int y = 5; y >= 0; y--)
                {
                    string line = Console.ReadLine();
                    for (int x = 0; x < 6; x++)
                    {
                        maze[x, y] = line[x];
                        if (line[x] == 'S')
                            start = Tuple.Create(x, y, 0);
                        if (line[x] == 'T')
                            Treasures.Add(Tuple.Create(x, y));
                    }
                }
                BFS(start);
                foreach (var t in found)
                    Console.Write(t == true ? "T" : "F");

                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void BFS(Tuple<int,int,int> start)
        {
            visited = new HashSet<Tuple<int, int, int>>();
            queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                vertex = queue.Dequeue();
                int x = vertex.Item1; int y = vertex.Item2; int dir = vertex.Item3;
                var possible = new List<char>();
               
                if (dir == 0) //Up
                    for (int i = y + 1; i < 5; i++)
                        possible.Add(maze[x, i]);

                else if (dir == 1) //Right
                    for (int i = x + 1; i < 5; i++)
                        possible.Add(maze[i, y]);

                else if (dir == 2) //Down
                    for (int i = y - 1; i > 0; i--)
                        possible.Add(maze[x, i]);

                else //Left
                    for (int i = x - 1; i > 0; i--)
                        possible.Add(maze[i, y]);

                foreach (char move in possible)
                {
                    if (move == 'U')
                        AddEdge(Tuple.Create(x, y + 1, dir));

                    else if (move == 'D')
                        AddEdge(Tuple.Create(x, y - 1, dir));

                    else if (move == 'L')
                        AddEdge(Tuple.Create(x - 1, y, dir));

                    else if (move == 'R')
                        AddEdge(Tuple.Create(x + 1, y, dir));

                    else if (move == 'C')
                        AddEdge(Tuple.Create(x, y, (dir + 1) % 4));

                    else if (move == 'B')
                        AddEdge(Tuple.Create(x, y, dir - 1));
                }
            }
        }

        static void AddEdge (Tuple<int,int,int> Point)
        {
            if (Point.Item1 < 0 || Point.Item2 < 0 || Point.Item1 > 5 || Point.Item2 > 5)
                return;

            if (Point.Item3 == -1)
            {
                int x = Point.Item1;
                int y = Point.Item2;
                Point = Tuple.Create(x, y, 3);
            }

            if (maze[Point.Item1, Point.Item2] == 'T' && !vertex.Equals(start))
            {
                found[Treasures.IndexOf(Tuple.Create(Point.Item1, Point.Item2))] = true;
                return;
            }

            if (!visited.Contains(Point) && maze[Point.Item1, Point.Item2] != '.' && maze[Point.Item1, Point.Item2] != 'T')
            {
                queue.Enqueue(Point);
                visited.Add(Point);
            }
        }
    }
}
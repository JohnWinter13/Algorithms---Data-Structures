using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hop_Skip_Jump
{
    class Program
    {
        static char[,] maze;
        static int W;
        static int H;

        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                string[] ln = Console.ReadLine().Split();
                W = int.Parse(ln[0]); H = int.Parse(ln[1]);
                maze = new char[W, H];
                Tuple<int, int> Hop = null;
                Tuple<int, int> Skip = null;
                Tuple<int, int> Jump = null;

                for (int y = H - 1; y >= 0; y--)
                {
                    string input = Console.ReadLine();
                    for (int x = 0; x < W; x++)
                    {
                        maze[x, y] = input[x];
                        if (input[x] == 'h')
                        {
                            Hop = Tuple.Create(x, y);
                            maze[x, y] = '.';
                        }
                        else if (input[x] == 's')
                        {
                            Skip = Tuple.Create(x, y);
                            maze[x, y] = '.';
                        }
                        else if (input[x] == 'j')
                        {
                            Jump = Tuple.Create(x, y);
                            maze[x, y] = '.';
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    Tuple<int, int> start = null;
                    if (i == 0)
                    {
                        Console.Write("HOP ");
                        start = Hop;
                    }
                    else if (i == 1)
                    {
                        Console.Write("SKIP ");
                        start = Skip;
                    }
                    else if (i == 2)
                    {
                        Console.Write("JUMP ");
                        start = Jump;
                    }
                    bool[] found = BFS(start, i);
                    if (found[0] == true)
                        Console.Write("C");
                    if (found[1] == true)
                        Console.Write("F");
                    if (found[2] == true)
                        Console.Write("T");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static bool[] BFS (Tuple<int, int> start, int id)
        {
            bool[] reached = new bool[3];
            var visited = new HashSet<Tuple<int, int>>();
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(start);
            visited.Add(start);
            
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                int x = vertex.Item1; int y = vertex.Item2;

                if (maze[x, y] == 'C')
                    reached[0] = true;
                else if (maze[x, y] == 'F')
                    reached[1] = true;
                else if (maze[x, y] == 'T')
                    reached[2] = true;

                bool flag = (y > 0 && maze[x, y - 1] == '.') || (y > 0 && maze[x, y - 1] == 'T') || (y > 0 && maze[x, y - 1] == 'F') || (y > 0 && maze[x, y - 1] == 'C') ? true : false;

                if (flag && maze[x, y] == '.' || flag && maze[x,y] == 'T' || flag && maze[x,y] == 'C' || flag && maze[x,y] == 'F') //We are falling
                {
                    if (!visited.Contains(Tuple.Create(x, y - 1)))
                    {
                        queue.Enqueue(Tuple.Create(x, y - 1));
                        visited.Add(Tuple.Create(x, y - 1));
                    }
                }

                else if (y != 0) //We are not falling
                {
                    if (x < W - 1 && !visited.Contains(Tuple.Create(x + 1, y)) && maze[x + 1, y] != '=')
                    {
                        queue.Enqueue(Tuple.Create(x + 1, y));
                        visited.Add(Tuple.Create(x + 1, y));
                    }

                    if (x > 0 && !visited.Contains(Tuple.Create(x - 1, y)) && maze[x - 1, y] != '=')
                    {
                        queue.Enqueue(Tuple.Create(x - 1, y));
                        visited.Add(Tuple.Create(x - 1, y));
                    }

                    if (y < H - 1  && !visited.Contains(Tuple.Create(x, y + 1)) && maze[x,y] == '#' && maze[x, y + 1] != '=')
                    {
                        queue.Enqueue(Tuple.Create(x, y + 1));
                        visited.Add(Tuple.Create(x, y + 1));
                    }

                    if (y > 0 && !visited.Contains(Tuple.Create(x, y - 1)) && maze[x,y - 1] == '#')
                    {
                        queue.Enqueue(Tuple.Create(x, y - 1));
                        visited.Add(Tuple.Create(x, y - 1));
                    }

                    //Special Moves
                    if (id == 0 || id == 2) //Hop and Jump
                    {
                        if (y < H - 1 && x < W - 1 && maze[x + 1, y + 1] != '=' && maze[x, y + 1] != '=' && !visited.Contains(Tuple.Create(x + 1, y + 1)))
                        {
                            queue.Enqueue(Tuple.Create(x + 1, y + 1));
                            visited.Add(Tuple.Create(x + 1, y + 1));
                        }

                        if (y < H - 1 && x > 0 && maze[x - 1, y + 1] != '=' && maze[x, y + 1] != '=' && !visited.Contains(Tuple.Create(x - 1, y + 1)))
                        {
                            queue.Enqueue(Tuple.Create(x - 1, y + 1));
                            visited.Add(Tuple.Create(x - 1, y + 1));
                        }

                        if (y < H - 1 && maze[x, y + 1] != '=' && !visited.Contains(Tuple.Create(x, y+1)))
                        {
                            queue.Enqueue(Tuple.Create(x, y + 1));
                            visited.Add(Tuple.Create(x, y + 1));
                        }
                    }

                    if (id == 1 || id == 2) //Skip and Jump
                    {
                        if (x > 1 && maze[x - 1, y] != '=' && maze[x - 2,y] != '=' && !visited.Contains(Tuple.Create(x -2, y)))
                        {
                            queue.Enqueue(Tuple.Create(x - 2, y));
                            visited.Add(Tuple.Create(x - 2, y));
                        }

                        if (x < W - 2 && maze[x + 1, y] != '=' && maze[x + 2, y] != '=' && !visited.Contains(Tuple.Create(x + 2, y)))
                        {
                            queue.Enqueue(Tuple.Create(x + 2, y));
                            visited.Add(Tuple.Create(x + 2, y));
                        }
                    }

                    if (id == 2) //Jump
                    {
                        if (x > 2 && maze[x - 1, y] != '=' && maze[x - 2, y] != '=' && maze[x -3,y] != '=' && !visited.Contains(Tuple.Create(x - 3, y)))
                        {
                            queue.Enqueue(Tuple.Create(x - 3, y));
                            visited.Add(Tuple.Create(x - 3, y));
                        }

                        if (x < W - 3 && maze[x + 1, y] != '=' && maze[x + 2, y] != '=' && maze[x + 3, y] != '=' && !visited.Contains(Tuple.Create(x + 3, y)))
                        {
                            queue.Enqueue(Tuple.Create(x + 3, y));
                            visited.Add(Tuple.Create(x + 3, y));
                        }

                        if (y < H - 1 && x < W - 2 && maze[x + 1, y + 1] != '=' && maze[x, y + 1] != '=' && maze[x + 2, y + 1] != '=' && maze[x + 1, y] != '=' && !visited.Contains(Tuple.Create(x + 2, y + 1)))
                        {
                            queue.Enqueue(Tuple.Create(x + 2, y + 1));
                            visited.Add(Tuple.Create(x + 2, y + 1));
                        }

                        if (y < H - 1 && x > 1 && maze[x - 1, y + 1] != '=' && maze[x, y + 1] != '=' && maze[x - 2, y+ 1] != '=' && maze[x -1, y] != '=' && !visited.Contains(Tuple.Create(x - 2, y + 1)))
                        {
                            queue.Enqueue(Tuple.Create(x - 2, y + 1));
                            visited.Add(Tuple.Create(x - 2, y + 1));
                        }

                        if (y < H - 2 && maze[x, y + 1] != '=' && maze[x, y + 2] != '=' && !visited.Contains(Tuple.Create(x, y + 2)))
                        {
                            queue.Enqueue(Tuple.Create(x, y + 2));
                            visited.Add(Tuple.Create(x, y + 2));
                        }
                    }
                }
            }
            return reached;
        }
    }
}
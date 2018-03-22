using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kayenne
{
    class Program
    {
        static int size = 100;
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                string[] cords = Console.ReadLine().Split();
                int x = int.Parse(cords[0]);
                int y = int.Parse(cords[1]);
                int[] hX = new int[size];
                int[] hY = new int[size];
                char[] states = new char[size];

                for (int i = 0; i < size; i++)
                {
                    string[] input = Console.ReadLine().Split();
                    hX[i] = int.Parse(input[0]);
                    hY[i] = int.Parse(input[1]);
                    states[i] = char.Parse(input[2]);
                }
                double democrats = 0;
                double total = 0;

                for (int i = x - 50; i <= x + 50; i++)
                {
                    for (int h = y - 50; h <= y + 50; h++)
                    {
                        if (DetermineEmpty(i, h, hX, hY) == false && radius(i, h, x, y) <= 2500) //50 * 50
                        {
                            total++;
                            List<string> Closest = FindDistance(i, h, hX, hY, states);
                            
                            int d = 0;
                            int r = 0;

                            foreach (string house in Closest)
                            {
                                if (house.Substring(house.IndexOf(':') + 1, 1) == "D")
                                    d++;

                                else
                                    r++;
                            }
                            if (d >= r)
                                democrats++;
                        }
                    }
                }
                Console.WriteLine((Math.Round(democrats / total * 100, 1).ToString("N1")));
            }
            Console.ReadKey();
        }

        private static bool DetermineEmpty(int x, int y, int[] hx, int[] hy)
        {
            for (int i = 0; i < size; i++)
            {
                if (hx[i] == x && hy[i] == y)
                {
                    return true; //House is occupied
                }
            }
            return false;
        }

        private static int radius(int x1, int y1, int x2, int y2)
        {
            int dx = x1 - x2;
            int dy = y1 - y2;
            return (dx * dx) + (dy * dy);
        }

        private static List<string> FindDistance(int x1, int y1, int[] x2, int[] y2, char[] state)
        {
            double[] distances = new double[size];
            char[] states = new char[size];
            for (int i = 0; i < size; i++)
            {
                distances[i] = Math.Sqrt((((x2[i] - x1) * (x2[i] - x1)) + (y2[i] - y1) * (y2[i] - y1)));
                states[i] = state[i];
            }
            Array.Sort(distances, states);
            
            List<string> Closest = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                Closest.Add(distances[i].ToString() + ":" + states[i]);
            }

            //Check for ties   
            double last = distances[2];
            double check = distances[3];       
            if (last == check)
            {
                Closest.Add(distances[3].ToString() + ":" + states[3]);
                for (int i = 4; i < distances.Length - 4; i++)
                {
                    double num = distances[i];

                    if (last == num)
                        Closest.Add(distances[i].ToString() + ":" + states[i]);

                    else
                        break;
                }
            }
            return Closest;
        }
    }
}
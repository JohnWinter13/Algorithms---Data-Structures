using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainView
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                int num = int.Parse(Console.ReadLine());
                string[] input = Console.ReadLine().Split();
                double[] mountains = new double[num];
                for (int i = 0; i < num; i++)
                    mountains[i] = double.Parse(input[i]);

                int[] views = new int[num];

                for (int i = 0; i < num; i++)
                {
                    int cnt = 0;
                    double compSlope = double.MinValue;

                    for (int j = i + 1; j < num; j++) //Right
                    {
                        double curSlope = GetSlope(mountains[j], mountains[i], j, i);
                        if (curSlope > compSlope)
                        {
                            compSlope = curSlope;
                            cnt++;
                        }
                    }

                    compSlope = double.MaxValue;
                    for (int j = i - 1; j >= 0; j--) //Left
                    {
                        double curSlope = GetSlope(mountains[j], mountains[i], j, i);
                        if (curSlope < compSlope)
                        {
                            compSlope = curSlope;
                            cnt++;
                        }
                    }
                    views[i] = cnt;
                }
                Console.WriteLine(Array.IndexOf(views, views.Max()) + 1);
            }
            Console.ReadKey();
        }

        private static double GetSlope(double x1, double x2, double y1, double y2)
        {
            return (x2 - x1) / (y2 - y1);
        }
    }
}
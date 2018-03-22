using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int h = 0; h < 10; h++)
            {
                int cost = int.Parse(Console.ReadLine());
                string[] percents = Console.ReadLine().Split(' ');
                double[] percentages = new double[percents.Length];
                for (int i = 0; i < percents.Length; i++)
                {
                    percentages[i] = double.Parse(percents[i]);
                }

                int smallCost = int.Parse(Console.ReadLine());

                double[] final = new double[percents.Length];
                for (int i = 0; i < percents.Length; i++)
                {
                    final[i] = percentages[i] * smallCost;
                }

                final[0] *= 12;
                final[1] *= 10;
                final[2] *= 7;
                final[3] *= 5;

                double total = 0;

                for (int i = 0; i < final.Length; i++)
                {
                    total += final[i];
                }
                if (total / 2 < cost)
                {
                    Console.WriteLine("YES");
                }

                else
                {
                    Console.WriteLine("NO");
                }
            }
            Console.ReadKey();
        }
    }
}
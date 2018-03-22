using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindieFast
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                int num = int.Parse(Console.ReadLine());
                int[] spinners = new int[101];
                string[] input = Console.ReadLine().Split(' ');

                for (int i = 0; i < num; i++)
                {
                    //spinners[i] = int.Parse(input[i]);
                    spinners[int.Parse(input[i])]++;
                }

                string[] tIn = Console.ReadLine().Split(' ');

                List<int> result = new List<int>();
                for (int i = 1; i <= 100; i++)
                {
                    for (int h = 1; h <= 100; h++)
                    {
                        for (int f = 1; f <= 100; f++)
                        {
                            if (spinners[i] > 0 && spinners[h] > 0 && spinners[f] > 0)
                            {
                                result.Add((i + h) + f);
                                result.Add((i * h) + f);
                                result.Add((i + h) * f);
                                result.Add((i * h) * f);
                            }
                        }
                    }
                }

                int[] targets = new int[5];
                char[] output = new char[5];
                for (int i = 0; i < 5; i++)
                {
                    targets[i] = int.Parse(tIn[i]);
                    output[i] = (result.Contains(targets[i]) ? 'T' : 'F');
                }
                Console.WriteLine(output);
                Console.ReadKey();
            }
        }
    }
}
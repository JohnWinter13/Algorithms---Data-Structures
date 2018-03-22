using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PassOrFail
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int y = 0; y < 10; y++)
            {
                string[] weightsIn = Console.ReadLine().Split(' ');
                int num = int.Parse(Console.ReadLine());
                string[] marks = new string[num];

                for (int i = 0; i < num; i++)
                {
                    marks[i] = Console.ReadLine();
                }

                double[] markWeights = new double[4];
                double[] weightT = new double[num];
                double[] weightA = new double[num];
                double[] weightP = new double[num];
                double[] weightQ = new double[num];

                for (int i = 0; i < 4; i++)
                {
                    markWeights[i] = double.Parse(weightsIn[i]);
                }

                int index = 0;
                int secondIndex = 0;

                for (int i = 0; i < num; i++)
                {
                    index = 0;
                    secondIndex = 0;
                    weightT[i] = double.Parse(marks[i].Substring(0, marks[i].IndexOf(' ')));
                    index = marks[i].IndexOf(' ') + 1;
                    secondIndex = marks[i].IndexOf(' ', index);
                    weightA[i] = double.Parse(marks[i].Substring(index, secondIndex - index));
                    index = secondIndex + 1;
                    secondIndex = marks[i].IndexOf(' ', index);
                    weightP[i] = double.Parse(marks[i].Substring(index, secondIndex - index));
                    index = secondIndex + 1;
                    weightQ[i] = double.Parse(marks[i].Substring(index, marks[i].Length - index));
                    //Console.WriteLine(weightT[i] + " " + weightA[i] + " " + weightP[i] + " " + weightQ[i]);
                }
                double[] finalPercent = new double[num];
                int passed = 0;
                for (int i = 0; i < num; i++)
                {
                    finalPercent[i] = (weightT[i] * markWeights[0] / 100) + (weightA[i] * markWeights[1] / 100) + (weightP[i] * markWeights[2] / 100) + (weightQ[i] * markWeights[3] / 100);
                    //Console.WriteLine(finalPercent[i]);
                    if (finalPercent[i] >= 50)
                    {
                        passed++;
                    }
                    else if (finalPercent[i] > 49.9999999999999 && Math.Round(finalPercent[i]) == 50)
                    {
                        passed++;
                    }
                }

                Console.WriteLine(passed);
                Console.ReadKey();
            }          
        }
    }
}
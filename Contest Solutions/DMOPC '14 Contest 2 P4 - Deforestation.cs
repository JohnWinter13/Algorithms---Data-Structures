using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deforestation
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] trees = new int[num + 1];
            for (int i = 1; i <= num; i++)
                trees[i] = int.Parse(Console.ReadLine()) + trees[i - 1];

            int ques = int.Parse(Console.ReadLine());
            var output = new StringBuilder();
            for (int i = 0; i < ques; i++)
            {
                string[] input = Console.ReadLine().Split();
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);
                output.AppendLine((trees[b + 1] - trees[a]).ToString());
            }
            Console.WriteLine(output);
            Console.ReadKey();           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucas__Other_Tower
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                string[] input = Console.ReadLine().Split(); int n = int.Parse(input[0]);
                Console.WriteLine(n * 2 - 1);
            }
            Console.ReadKey();
        }
    }
}
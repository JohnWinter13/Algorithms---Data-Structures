using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baker_Brie
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                string[] input = Console.ReadLine().Split();
                int fran = int.Parse(input[0]);
                int days = int.Parse(input[1]);
                int result = 0;
                int[,] shops = new int[fran, days];

                for (int y = 0; y < days; y++)
                {
                    string[] line = Console.ReadLine().Split();
                    for (int x = 0; x < fran; x++)
                    {
                        shops[x, y] = int.Parse(line[x]);
                    }
                }

                for (int h = 0; h < days; h++)
                {
                    int temp = 0;
                    for (int i = 0; i < shops.GetLength(0); i++)
                        temp += (shops[i, h]);

                    result = UpdateCount(temp, result);
                }

                for (int h = 0; h < fran; h++)
                {
                    int temp = 0;
                    for (int i = 0; i < shops.GetLength(1); i++)
                        temp += (shops[h, i]);

                    result = UpdateCount(temp, result);
                }

                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        private static int UpdateCount(int n, int result)
        {
            if (n % 13 == 0)
                result += n / 13;
            return result;
        }
    }
}
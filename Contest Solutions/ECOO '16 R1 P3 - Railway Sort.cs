using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Sort
{
    class Program
    {


        static void Main(string[] args)
        {            
            for (int q = 0; q < 10; q++)
            {
                int num = int.Parse(Console.ReadLine());
                string[] input = Console.ReadLine().Split();
                List<int> trains = new List<int>();

                for (int i = 0; i < num; i++)
                {
                    int train = int.Parse(input[i]);
                    trains.Add(train);
                }

                int search = 0;
                int presearch = 0;
                int count = 0;

                for (int i = num; i > 1; i--)
                {
                    foreach (int t2 in trains)
                    {
                        if (t2 == i)
                        {
                            search = trains.IndexOf(t2);
                        }

                        if (t2 == i - 1)
                        {
                            presearch = trains.IndexOf(t2);
                        }
                    }
                    if (presearch > search)
                    {
                        int temp = trains[presearch];
                        trains.Remove(trains[presearch]);
                        trains.Insert(0, temp);
                        count += presearch;
                    }
                }
                Console.WriteLine(count);
            }
            Console.ReadKey();
        }
    }
}
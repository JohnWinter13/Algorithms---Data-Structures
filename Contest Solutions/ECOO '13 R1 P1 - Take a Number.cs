using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            //List<int> NeedServe = new List<int>();
            int NeedServe = 0;
            bool keep = true;
            int lates = 0;

            while (keep == true)
            {
                string input = Console.ReadLine();
                if (input == "TAKE")
                {
                    if (num + 1 == 1000)
                    {
                        num = 1;
                    }
                    else
                    {
                        num++;
                    }
                    NeedServe++;
                    lates++;
                }

                else if (input == "SERVE")
                {
                    NeedServe--;
                }

                else if (input == "CLOSE")
                {
                    Console.WriteLine(lates + " " + NeedServe + " " + num);
                    lates = 0;
                    NeedServe = 0;
                }

                else
                {
                    keep = false;
                }
            }
            Console.ReadKey();
        }
    }
}
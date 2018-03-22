using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard_Windows
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {

                string[] l1 = Console.ReadLine().Split();
                int n = int.Parse(l1[0]);
                int m = int.Parse(l1[1]);
                string[] rules = new string[4];
                for (int i = 0; i < 4; i++)
                    rules[i] = Console.ReadLine();
                string bot = Console.ReadLine();
                Console.ReadLine();
                for (int j = 0; j < m - 1; j++)
                {
                    StringBuilder next = new StringBuilder();
                    for (int i = 0; i < n; i++)
                    {
                        for (int h = 0; h < 4; h++)
                        {
                            if (i == n - 1)
                            {
                                if (bot[i - 1].ToString() + bot[0] == rules[h].Substring(0, 2))
                                {
                                    next.Append(rules[h].Substring(3, 1));
                                }
                            }

                            else if (i == 0)
                            {
                                if (bot[n - 1].ToString() + bot[i + 1] == rules[h].Substring(0, 2))
                                {
                                    next.Append(rules[h].Substring(3, 1));
                                }
                            }

                            else if (bot[i - 1].ToString() + bot[i + 1] == rules[h].Substring(0, 2))
                            {
                                next.Append(rules[h].Substring(3, 1));
                            }
                        }
                    }
                    bot = next.ToString();

                }
                Console.WriteLine(bot);
            }
            Console.ReadKey();      
        }
    }
}
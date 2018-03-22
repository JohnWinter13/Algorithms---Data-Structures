using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate_Chewsday
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int h = 0; h < 10; h++)
            {
                int num = int.Parse(Console.ReadLine());
                int[] p = new int[num];
                int[] f = new int[num];
                int[] g = new int[num];
                int[] total = new int[num];
                string[] names = new string[num];
                string input = null;

                //variable countere
                int namesIndex = -1;
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "*")
                    {
                        break;
                    }

                    else if (input.Substring(0, 1) != "J")
                    {
                        namesIndex++;
                        names[namesIndex] = input;
                    }

                    else
                    {
                        p[namesIndex] += int.Parse(input.Substring(2, 1));
                        f[namesIndex] += int.Parse(input.Substring(4, 1));
                        g[namesIndex] += int.Parse(input.Substring(6, 1));
                    }
                    total[namesIndex] = p[namesIndex] + f[namesIndex] + g[namesIndex];
                }
                int[] sortedArr = new int[num];
                Array.Copy(total, sortedArr, num);
                Array.Sort(sortedArr);
                Array.Reverse(sortedArr);
                int duplicates = 0;
                for (int i = 0; i < sortedArr.Length; i++)
                {
                    if (sortedArr[0] == total[i])
                    {
                        duplicates++;
                    }

                    else if (sortedArr[0] != total[i])
                    {
                        total[i] = 0;
                        g[i] = 0;
                        f[i] = 0;
                        p[i] = 0;
                    }
                }

                if (duplicates == 1)
                {
                    for (int i = 0; i < total.Length; i++)
                    {
                        if (sortedArr[0] == total[i])
                        {
                            Console.WriteLine(names[i]);
                        }

                        else
                        {
                            total[i] = 0;
                            g[i] = 0;
                            f[i] = 0;
                            p[i] = 0;
                        }
                    }
                }

                else
                {
                    int dupG = 0;
                    int dupF = 0;
                    int dupP = 0;

                    int[] sortedG = new int[num];
                    Array.Copy(g, sortedG, num);
                    Array.Sort(sortedG);
                    Array.Reverse(sortedG);

                    for (int i = 0; i < num; i++)
                    {
                        if (g[i] == sortedG[0])
                        {
                            dupG++;
                        }

                        else
                        {
                            total[i] = 0;
                            g[i] = 0;
                            f[i] = 0;
                            p[i] = 0;
                        }
                    }

                    int[] sortedF = new int[num];
                    Array.Copy(f, sortedF, num);
                    Array.Sort(sortedF);
                    Array.Reverse(sortedF);

                    if (dupG == 1)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            if (g[i] == sortedG[0])
                            {
                                Console.WriteLine(names[i]);
                            }
                        }
                    }

                    else
                    {
                        for (int i = 0; i < num; i++)
                        {
                            if (f[i] == sortedF[0])
                            {
                                dupF++;
                            }

                            else
                            {
                                total[i] = 0;
                                g[i] = 0;
                                f[i] = 0;
                                p[i] = 0;
                            }
                        }
                    }

                    int[] sortedP = new int[num];
                    Array.Copy(p, sortedP, num);
                    Array.Sort(sortedP);
                    Array.Reverse(sortedP);

                    if (dupF == 1)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            if (f[i] == sortedF[0])
                            {
                                Console.WriteLine(names[i]);
                            }

                        }
                    }

                    else
                    {
                        for (int i = 0; i < num; i++)
                        {
                            if (p[i] == sortedP[0])
                            {
                                dupP++;
                            }

                            else
                            {
                                total[i] = 0;
                                g[i] = 0;
                                f[i] = 0;
                                p[i] = 0;
                            }
                        }

                        if (dupP == 1)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                if (p[i] == sortedP[0])
                                {
                                    Console.WriteLine(names[i]);
                                }
                            }
                        }

                        else
                        {
                            StringBuilder output = new StringBuilder();
                            for (int i = 0; i < num; i++)
                            {
                                if (p[i] == sortedP[0])
                                {
                                    output.Append(names[i] + ",");
                                }
                            }
                            Console.WriteLine(output.ToString().TrimEnd(','));
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
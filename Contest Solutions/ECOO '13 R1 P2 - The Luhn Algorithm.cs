using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Luhn_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 5; tests++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                //long[] nums = new long[input.Length];

                //for (long i = 0; i < nums.Length; i++)
                //{
                //   nums[i] = long.Parse(input[i]);
                //}
                List<long> Totals = new List<long>();
                foreach (string num in nums)
                {
                    char[] temp = num.ToString().ToCharArray();
                    Array.Reverse(temp);
                    bool flip = true;
                    long total = 0;
                    foreach (char digit in temp)
                    {
                        if (flip == true)
                        {
                            long number = long.Parse(digit.ToString());
                            number *= 2;
                            flip = false;
                            if (number.ToString().Length > 1)
                            {
                                char[] mini = number.ToString().ToCharArray();
                                for (int i = 0; i < mini.Length; i++)
                                {
                                    total += int.Parse(mini[i].ToString());
                                }
                            }

                            else
                            {
                                total += number;
                            }
                        }

                        else if (flip == false)
                        {
                            flip = true;
                            total += long.Parse(digit.ToString());
                        }
                    }
                    Totals.Add(total);
                }

                StringBuilder answer = new StringBuilder();
                for (int i = 0; i < 5; i++)
                {
                    for (int h = 0; h < 10; h++)
                    {
                        if ((Totals[i] + h) % 10 == 0)
                        {
                            answer.Append(h);
                            break;
                        }
                    }
                }
             Console.WriteLine(answer);
            }
            Console.ReadKey();
        }
    }
}
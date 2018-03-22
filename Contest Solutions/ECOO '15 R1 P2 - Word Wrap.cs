using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWrap
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                int num = int.Parse(Console.ReadLine());
                List<string> input = Console.ReadLine().Split().ToList();
                List<string> output = new List<string>();
                int counter = 0;
                string temp = null;

                while (input.Count > 0)
                {
                    while (counter <= num)
                    {
                        if (input.Count == 0)
                        {
                            break;
                        }

                        if (input[0].Length > num) //If the word is too big for the viewing window, chop it up, remove it from the list and add the remainder to the list.
                        {
                            if (temp != null) //If we did not already write the previous terms, write them now.
                            {
                                output.Add(temp);
                            }

                            temp = input[0].Substring(0, num);
                            string half = input[0].Substring(num, input[0].Length - num);
                            input.Remove(input[0]);
                            input.Insert(0, half);
                            break;
                        }

                        else if (counter + input[0].Length <= num)
                        {
                            counter += input[0].Length + 1;
                            temp += input[0] + " ";
                            input.Remove(input[0]);
                        }

                        else
                        {
                            break;
                        }
                    }
                    output.Add(temp);
                    counter = 0;
                    temp = null;
                }

                foreach (var item in output)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("=====");
            }
            Console.ReadKey();
        }
    }
}
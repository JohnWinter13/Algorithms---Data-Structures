using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                int num = int.Parse(Console.ReadLine());
                int count = 0;
                var Family = new Dictionary<string, int>();
                for (int i = 0; i < num; i++)
                {
                    string ln = Console.ReadLine();
                    string [] input = ln.Split('.');
                    int index = 1;
                    for (int j = 0; j < input.Length; j++)
                    {
                        int curr = int.Parse(input[j]);
                        string temp = ln.Substring(0, index);
                        if (!Family.ContainsKey(temp))
                        {
                            Family.Add(temp, curr);
                            count = (count + curr) % 1000000007;
                        }

                        else if (Family[temp] < curr)
                        {
                            count = (count + (curr - Family[temp])) % 1000000007;
                            Family[temp] = curr;
                        }
                        index = ln.IndexOf('.', index) + 1;
                    }
                }
                Console.WriteLine(count + 1);
            }
            Console.ReadKey();
        }
    }
}
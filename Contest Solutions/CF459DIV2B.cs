using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF459DIV2BCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ln = Console.ReadLine().Split();
            int n = int.Parse(ln[0]), m = int.Parse(ln[1]);
            var servers = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                ln = Console.ReadLine().Split();
                servers.Add(ln[1], ln[0]);
            }
            for (int i = 0; i < m; i++)
            {
                ln = Console.ReadLine().Split();
                string command = ln[1].Substring(0, ln[1].Length - 1);
                Console.WriteLine(ln[0] + " " + ln[1] + " #" + servers[command]);
            }
            Console.ReadKey();
        }
    }
}

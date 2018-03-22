using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGPC_2017_P2_CS
{
class Program
{
    static void Main(string[] args)
    {
        string[] ln = Console.ReadLine().Split();
        int n = int.Parse(ln[0]);
        double s = double.Parse(ln[1]);
        int exc = 0, great = 0, good = 0, bad = 0, miss = 0;
        int combo = 0, maxcombo = 0;
        for (int i = 0; i < n; i++)
        {
            double temp = Math.Abs(double.Parse(Console.ReadLine()));
            if (temp <= 50)
            {
                exc++;
                combo++;
            }
            else if (temp >= 51 && temp <= 100)
            {
                great++;
                combo++;
            }
            else if (temp >= 101 && temp <= 150)
            {
                good++;
                combo++;
            }
            else if (temp >= 151 && temp <= 200)
            {
                bad++;
                combo++;
            }
            else if (temp > 200)
            {
                maxcombo = Math.Max(combo, maxcombo);
                combo = 0;
                miss++;
            }
            maxcombo = Math.Max(combo, maxcombo);
        }
        double score = 1.5 * exc + great + good + 0.5 * bad - miss + 0.5 * maxcombo;
        if (score <= 0)
            Console.WriteLine("0.0");
        else if (s >= score)
            Console.WriteLine("0.0");
        else
            Console.WriteLine(Math.Round(score - s, 1).ToString("0.0"));
        Console.ReadKey();
    }
}
}
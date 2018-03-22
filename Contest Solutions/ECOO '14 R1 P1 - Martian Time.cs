using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//stupid question
namespace Martian_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                string[] s = Console.ReadLine().Trim().Split(); int day = int.Parse(s[0]); int hour = int.Parse(s[1]); int minute = int.Parse(s[2]);
                Console.WriteLine(FindTime(day, hour, minute));
            }
            Console.ReadKey();
        }

        public static string FindTime(int d, int h, int m)
        {
            double seconds = ((d * 3600 * 24 + h * 3600 + m * 60) * (86400 / 88642.663)) + 2160;
            TimeSpan time = TimeSpan.FromSeconds(seconds);

            double temp = Math.Round(time.TotalSeconds);
            while (temp >= 3600)
                temp -= 3600;
            while (temp >= 60)
                temp -= 60;

            if (temp >= 30)
            {
                string t = time.ToString(@"dd\,\ hh\:mm");
                int index = t.LastIndexOf(":");
                int minutes = int.Parse(t.Substring(index + 1, 2)) + 1;
                if (minutes.ToString().Length > 1)
                    return ("Day " + time.ToString(@"dd\,\ hh\:") + minutes);
                else
                    return ("Day " + time.ToString(@"dd\,\ hh\:") + "0" + minutes);
            }    
                   
           return("Day " + time.ToString(@"dd\,\ hh\:mm"));
        }
    }
}
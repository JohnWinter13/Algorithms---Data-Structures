using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_Pin_Trig
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int tests = 0; tests < 10; tests++)
            {
                string[] input = Console.ReadLine().Split();
                double x = double.Parse(input[0]) * Math.Pow(10, double.Parse(input[1]));
                double y = double.Parse(input[2]) * Math.Pow(10, double.Parse(input[3]));
                double length = double.Parse(input[4]) * Math.Pow(10, double.Parse(input[5]));

                StringBuilder output = new StringBuilder();

                for (int i = 0; i < 5; i++)
                {
                    string[] line = Console.ReadLine().Split();
                    double xx = double.Parse(line[0]) * Math.Pow(10, double.Parse(line[1]));
                    double yy = double.Parse(line[2]) * Math.Pow(10, double.Parse(line[3]));
                    int pin = DetermineLocation((xx - x), (yy - y), length);
                    output.Append(pin + " ");
                }

                Console.WriteLine(output.ToString().TrimEnd(' '));
            }
            Console.ReadKey();
        }

        private static int DetermineLocation(double x, double y, double length)
        {
            int pin = 0;
            if (x == 0 && y == 0)
                pin = 1;

            else if (x == 0 && y > 0)
                pin = 5;

            
            else if (x > 0) //To the right
            {
                if (y < length / 2)
                    pin = 3;

                else if (y >= length / 1.5 && x >= length / 2.1)
                    pin = 10;

                else if (y > length / 2 && y < length && y < length - (length / 3))
                    pin = 6;

                else
                    pin = 9;

            }

            else if (x < 0) //To the left
            {
                if (y < length / 2)
                    pin = 2;

                else if (y >= length / 1.5 && -x >= length / 2.1)
                    pin = 7;

                else if (y > length / 2 && y < length && y < length - (length / 3))
                    pin = 4;

                else
                    pin = 8;
            }
            return pin;
        }
    }
}
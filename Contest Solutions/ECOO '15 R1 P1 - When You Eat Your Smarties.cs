using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartiesDMOJ
{
    class Program
    {
        static int blue = 0;
        static int green = 0;
        static int orange = 0;
        static int yellow = 0;
        static int pink = 0;
        static int violet = 0;
        static int brown = 0;
        static int red = 0;
        static int colors = 0;
        static int time = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                string color = "";
                bool end = false;
                while (end == false)
                {
                    color = Console.ReadLine();
                    if (color == "blue")
                    {
                        blue++;
                    }
                    else if (color == "green")
                    {
                        green++;
                    }

                    else if (color == "yellow")
                    {
                        yellow++;
                    }
                    else if (color == "orange")
                    {
                        orange++;
                    }
                    else if (color == "pink")
                    {
                        pink++;
                    }
                    else if (color == "violet")
                    {
                        violet++;
                    }
                    else if (color == "brown")
                    {
                        brown++;
                    }
                    else if (color == "red")
                    {
                        red++;
                    }
                    else if (color == "end of box")
                    {
                        end = true;
                    }
                }
                colors = orange;
                GetCount();
                colors = blue;
                GetCount();
                colors = green;
                GetCount();
                colors = yellow;
                GetCount();
                colors = pink;
                GetCount();
                colors = violet;
                GetCount();
                colors = brown;
                GetCount();

                for (int h = 0; h < red; h++)
                {
                    time = time + 16;
                }

                Console.WriteLine(time);
                //Console.ReadKey();
                blue = 0;
                green = 0;
                orange = 0;
                yellow = 0;
                pink = 0;
                violet = 0;
                brown = 0;
                red = 0;
                colors = 0;
                time = 0;
            }


        }

        private static void GetCount()
        {
            while (colors != 0)
            {
                if (colors >= 7)
                {
                    time += 13;
                    colors -= 7;
                }
                else if (colors < 7)
                {
                    time += 13;
                    colors = 0;
                    break;
                }
            }
        }
    }
}
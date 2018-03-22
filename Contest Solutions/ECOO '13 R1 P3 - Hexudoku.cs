using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
		//legendary solution
                char[] l1 = Console.ReadLine().ToCharArray();
                char[] l2 = Console.ReadLine().ToCharArray();
                char[] l3 = Console.ReadLine().ToCharArray();
                char[] l4 = Console.ReadLine().ToCharArray();
                char[] l5 = Console.ReadLine().ToCharArray();
                char[] l6 = Console.ReadLine().ToCharArray();
                char[] l7 = Console.ReadLine().ToCharArray();
                char[] l8 = Console.ReadLine().ToCharArray();
                char[] l9 = Console.ReadLine().ToCharArray();
                char[] l10 = Console.ReadLine().ToCharArray();
                char[] l11 = Console.ReadLine().ToCharArray();
                char[] l12 = Console.ReadLine().ToCharArray();
                char[] l13 = Console.ReadLine().ToCharArray();
                char[] l14 = Console.ReadLine().ToCharArray();
                char[] l15 = Console.ReadLine().ToCharArray();
                char[] l16 = Console.ReadLine().ToCharArray();

                int count = 0;

                count += SolveRow(l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16);
                count += SolveRow(l2, l1, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16);
                count += SolveRow(l3, l1, l2, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16);
                count += SolveRow(l4, l1, l2, l3, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16);

                count += SolveRow(l5, l6, l7, l8, l1, l2, l3, l4, l9, l10, l11, l12, l13, l14, l15, l16);
                count += SolveRow(l6, l5, l7, l8, l1, l2, l3, l4, l9, l10, l11, l12, l13, l14, l15, l16);
                count += SolveRow(l7, l5, l6, l8, l1, l2, l3, l4, l9, l10, l11, l12, l13, l14, l15, l16);
                count += SolveRow(l8, l5, l6, l7, l1, l2, l3, l4, l9, l10, l11, l12, l13, l14, l15, l16);

                count += SolveRow(l9, l10, l11, l12, l1, l2, l3, l4, l5, l6, l7, l8, l13, l14, l15, l16);
                count += SolveRow(l10, l9, l11, l12, l1, l2, l3, l4, l5, l6, l7, l8, l13, l14, l15, l16);
                count += SolveRow(l11, l9, l10, l12, l1, l2, l3, l4, l5, l6, l7, l8, l13, l14, l15, l16);
                count += SolveRow(l12, l9, l10, l11, l1, l2, l3, l4, l5, l6, l7, l8, l13, l14, l15, l16);

                count += SolveRow(l13, l14, l15, l16, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12);
                count += SolveRow(l14, l13, l15, l16, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12);
                count += SolveRow(l15, l13, l14, l16, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12);
                count += SolveRow(l16, l13, l14, l15, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12);

                Console.WriteLine(count);
            }
            Console.ReadKey();
        }

        private static int SolveRow(char[] l1, char[] l2, char[] l3, char[] l4, char[] l5, char[] l6, char[] l7, char[] l8, char[] l9, char[] l10, char[] l11, char[] l12, char[] l13, char[] l14, char[] l15, char[] l16)
        {
            char[] hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            int counter = 0;
            for (int i = 0; i < l1.Length; i++)
            {
                if (l1[i] == '-')
                {
                    foreach (var letter in hex)
                    {
                        if (l1.Contains(letter) == false) //Row
                        {
                            //Column (sick spaghetti recipe)
                            if (l2[i] != letter && l3[i] != letter && l4[i] != letter && l5[i] != letter && l6[i] != letter && l7[i] != letter && l8[i] != letter && l9[i] != letter && l10[i] != letter && l11[i] != letter && l12[i] != letter && l13[i] != letter && l14[i] != letter && l15[i] != letter && l16[i] != letter)
                            {
                                //Quadrant
                                int quadrant = DetermineQuadrant(i);
                                bool possible = DetermineSolution(quadrant, l2, l3, l4, letter);

                                if (possible == true)
                                {
                                    l1[i] = letter;
                                    counter++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return counter;
        }

        private static bool DetermineSolution(int quadrant, char[]l2, char[]l3, char[]l4, char letter)
        {
            bool possible = true;
            if (quadrant == 1)
            {
                for (int h = 0; h < 4; h++)
                {
                    if (l2[h] == letter || l3[h] == letter || l4[h] == letter)
                    {
                        possible = false;
                    }
                }
            }

            else if (quadrant == 2)
            {
                for (int h = 4; h < 8; h++)
                {
                    if (l2[h] == letter || l3[h] == letter || l4[h] == letter)
                    {
                        possible = false;
                    }
                }
            }

            else if (quadrant == 3)
            {
                for (int h = 8; h < 12; h++)
                {
                    if (l2[h] == letter || l3[h] == letter || l4[h] == letter)
                    {
                        possible = false;
                    }
                }
            }

            else
            {
                for (int h = 12; h < 16; h++)
                {
                    if (l2[h] == letter || l3[h] == letter || l4[h] == letter)
                    {
                        possible = false;
                    }
                }
            }
            return possible;
        }

        private static int DetermineQuadrant(int index)
        {
            if (index == 0 || index == 1 || index == 2 || index == 3)
            {
                index = 1;
            }

            else if (index == 4 || index == 5 || index == 6 || index == 7)
            {
                index = 2;
            }

            else if (index == 8 || index == 9 || index == 10 || index == 11)
            {
                index = 3;
            }

            else
            {
                index = 4;
            }
            return index;
        }
    }
}
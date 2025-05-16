using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Globalization;

namespace D3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader Dir = new StreamReader("Dir.txt"))
            {
                int x = 2000;
                int y = 2000;
                int xi = 2000;
                int yi = 2000;

                int total = 0;
                int[,] houses = new int[4000,4000];
                for (int i = 0; i < 4000; i++)
                {
                    for (int j = 0; j < 4000; j++)
                    {
                        houses[i,j] = 0;
                    }
                }
                houses[2000,2000] = 1;

                string dir = Dir.ReadLine();

                for (int i = 0; i < dir.Length; i++)
                {
                    if (dir[i] == '^')
                    {
                        if(i%2 == 0)
                            y++;
                        else
                            yi++;
                    }
                    else if (dir[i] == '>')
                    {
                        if(i%2 == 0)
                            x++;
                        else
                            xi++;
                    }
                    else if (dir[i] == 'v')
                    {
                        if(i%2 == 0)
                            y--;
                        else
                            yi--;
                    }
                    else if (dir[i] == '<')
                    {
                        if(i%2 == 0)
                            x--;
                        else
                            xi--;
                    }
                    else
                    {
                        break;
                    }

                    if (i%2 == 0)
                        houses[x,y]++;
                    else
                        houses[xi,yi]++;
                }

                for (int i = 0; i < 4000; i++)
                {
                    for (int j = 0; j < 4000; j++)
                    {
                        if (houses[i,j] >= 1)
                        {
                            total++;
                        }
                    }
                }

                Console.WriteLine(total);
            }
        }
    }
}

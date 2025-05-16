using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Globalization;
using System.IO.Pipes;
using System.Configuration.Assemblies;
using System.Formats.Asn1;

namespace D11
{
    class Program
    {
        public static int Time(int[,] stats, int deer, int seconds)
        {
            int length = 0;
            int temp = 0;
            for (int i = 1; i < seconds + 1; i++)
            {
                temp = i;

                while (temp > stats[deer,1] + stats[deer,2])
                {
                    temp -= stats[deer,1] + stats[deer,2];
                }

                if (temp <= stats[deer,1])
                {
                    length += stats[deer,0];
                }
            }
            return length;
        }
        public static void Main(string[] args)
        {
            int[,] stats = new int[,]
            {
                {19, 7, 124, 0, 0},
                {3, 15, 28, 0, 0},
                {19, 9, 164, 0, 0},
                {19, 9, 158, 0, 0},
                {13, 7, 82, 0, 0},
                {25, 6, 145, 0, 0},
                {14, 3, 38, 0, 0},
                {3, 16, 37, 0, 0},
                {25, 6, 143, 0, 0}
            };

            int high;
            int temp;
            const int seconds = 2503;

            for (int i = 1; i < seconds + 1; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    temp = i;

                    while (temp > stats[j,1] + stats[j,2])
                    {
                        temp -= stats[j,1] + stats[j,2];
                    }

                    if (temp <= stats[j,1])
                    {
                        stats[j,3] += stats[j,0];
                    }
                }
                
                high = stats[0,3];
                for (int j = 1; j < 9; j++)
                {
                    if (high < stats[j,3])
                    {
                        high = stats[j,3];
                    }
                }
                

                for (int j = 0; j < 9; j++)
                {
                    if (stats[j,3] == high)
                    {
                        stats[j,4]++;
                    }
                }
                
                for (int j = 0; j < 9; j++)
                {
                    //Console.WriteLine(stats[j,4]);
                }
                //Console.WriteLine();
                for (int j = 0; j < 9; j++)
                {
                    //Console.WriteLine(stats[j,3]);
                }
                //Console.ReadLine();
            }

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(stats[i,4]);
            }
            
        }
    }
}
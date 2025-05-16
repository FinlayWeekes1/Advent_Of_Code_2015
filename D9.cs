using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Runtime.ExceptionServices;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace D9
{
    public class Program
    {
        public static bool Check(string[,] dis, int[] attempt)
        {
            int[,] index = new int[,]
            {
                {1,2,3,4,5,6,7,8},
                {0,0,0,0,0,0,0,0},
            };

            for (int l = 0; l < attempt.Length; l++)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (dis[i,j] == Convert.ToString(attempt[l]))
                        {
                            index[1,i-1]++;
                        }
                    }
                }
            }

            int temp = 0;
            for (int i = 0; i < 8; i++)
            {
                if (index[1,i] == 1)
                {
                    temp++;
                }
                else if (index[1,i] != 2)
                {
                    return false;
                }
            }

            int row1q = -1;
            int row2q = -2;
            if (temp == 2)
            {
                for (int i = 0;  i < 8; i++)
                {
                    if (index[1,i] == 1)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (i != j && index[1,j] == 1)
                            {
                                for (int q = 1; q < 9; q++)
                                {
                                    for (int w = 0; w < attempt.Length; w++)
                                    {
                                        if (dis[index[0,i],q] == Convert.ToString(attempt[w]))
                                        {
                                            row1q = q;
                                        }
                                    }
                                }
                                for (int q = 1; q < 9; q++)
                                {
                                    for (int w = 0; w < attempt.Length; w++)
                                    {
                                        if (dis[index[0,j],q] == Convert.ToString(attempt[w]))
                                        {
                                            row2q = q;
                                        }
                                    }
                                }

                                if (row1q == row2q)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Main(string[] args)
        {
            string[,] dis = new string[,]
            {
                {".", "Tristram", "AlphaCentauri", "Snowdin", "Tambi", "Faerun", "Norrath", "Straylight", "Arbre"},
                {"Tristram", ".", "34", "100", "63", "108", "111", "89", "132"},
                {"AlphaCentauri", "34", ".", "4", "79", "44", "147", "133", "74"},
                {"Snowdin", "100", "4", ".", "105", "95", "48", "88", "7"},
                {"Tambi", "63", "79", "105", ".", "68", "134", "107", "40"},
                {"Faerun", "108", "44", "95", "68", ".", "11", "66", "144"},
                {"Norrath", "111", "147", "48", "134", "11", ".", "115", "135"},
                {"Straylight", "89", "133", "88", "107", "66", "115", ".", "127"},
                {"Arbre", "132", "74", "7", "40", "144", "135", "127", "."},
            };

            int[] values = new int[]
            {4,7,11,34,40,44,48,63,66,68,74,79,88,89,95,100,105,107,108,111,115,127,132,133,134,135,144,147};
            
            // 312 is some random value i guessed that was too high
            int low = 150;
            int temp;
            int[] index = new int[7];
            
            for (int q = 0; q < values.Length; q++)
            {
                for (int w = 0; w < values.Length; w++)
                {
                    for (int e = 0; e < values.Length; e++)
                    {
                        for (int r = 0; r < values.Length; r++)
                        {
                            for (int t = 0; t < values.Length; t++)
                            {
                                for (int y = 0; y < values.Length; y++)
                                {
                                    for (int u = 0; u < values.Length; u++)
                                    {
                                        if (q != w && q != e && q != r && q != t && q != y && q != u && w != e && w != r && w != t && w != y && w != u && e != r && e != t && e != y && e != u && r != t && r != t && r != y && r != u && t != y && t != u && y != u)
                                        {
                                            //Console.WriteLine("Checking {1}+{2}+{3}+{4}+{5}+{6}+{7}.", values[q], values[q], values[w], values[e], values[r], values[t], values[y], values[u]);
                                            temp = 0;
                                            temp += values[q];
                                            temp += values[w];
                                            temp += values[e];
                                            temp += values[r];
                                            temp += values[t];
                                            temp += values[y];
                                            temp += values[u];

                                            if (temp > low)
                                            {
                                                index[0] = values[q]; index[1] = values[w]; index[2] = values[e]; index[3] = values[r]; index[4] = values[t]; index[5] = values[y]; index[6] = values[u];
                                                using (StreamWriter sw = new StreamWriter("Checking.txt", true))
                                                {
                                                    sw.WriteLine("Checking {0} ({1}+{2}+{3}+{4}+{5}+{6}+{7}).", temp, values[q], values[w], values[e], values[r], values[t], values[y], values[u]);
                                                }
                                                
                                                if (Check(dis, index))
                                                {
                                                    low = temp;
                                                    using (StreamWriter sw = new StreamWriter("Lows.txt", true))
                                                    {
                                                        sw.WriteLine("NEW LOW FOUND: {0}! ({1}+{2}+{3}+{4}+{5}+{6}+{7}).", temp, values[q], values[w], values[e], values[r], values[t], values[y], values[u]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //Console.ReadLine();
                                }
                            }
                        }
                        Console.WriteLine("Completed e{0}", e);
                    }
                    Console.WriteLine("\x1b[32mCompleted w{0}\x1b[0m", w);
                }
                Console.WriteLine("\x1b[33mCompleted q{0}\x1b[0m", q);
            }
            Console.WriteLine("LOWEST: {0}", low);
        }
    }
}

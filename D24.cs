using System;
using System.IO;
using System.Reflection.Metadata;

namespace D20
{
    public static class Program
    {
        public static int[] g0(int[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = 0;
            }
            return g;
        }
        public static void Main(string[] args)
        {
            const int pacCount = 10;
            int[] pacs = new int[pacCount];
            int[] g1 = new int[pacCount];
            int[] g2 = new int[pacCount];
            int[] g3 = new int[pacCount];
            int[] test = new int[pacCount];
            g1 = g0(g1);
            g2 = g0(g2);
            g3 = g0(g3);
            test = g0(test);
            int max = 0;
            int total = 0;
            bool found = false;

            using (StreamReader sr = new StreamReader("Pac.txt"))
            {
                for (int i = 0; i < pacCount; i++)
                {
                    pacs[i] = int.Parse(sr.ReadLine());
                    max += pacs[i];
                }
            }
            max /= 3;

            test[0] = max-1;
            test[1] = 1;
            int index = 0;
            while(found == false)
            {
                if (test[index] <)


                for (int i = 0; i < pacCount; i++)
                {
                    if (test[i] != 0)
                    {
                        for (int j = 0; j < pacCount; j++)
                        {
                            if (test[i] == pacs[j])
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found == false)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
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
        public static bool Calories500(int[] reci, int[,] ing)
        {
            int total = 0;
            for (int i = 0; i < 4; i++)
            {
                total += (reci[i] * ing[i, 4]);
            }
            if (total != 500)
            {
                return false;
            }
            return true;
        }
        public static int Total(int[] reci, int[,] ing)
        {
            int total = 1;

            for (int i = 0; i < 4; i++)
            {
                total *= Stat(reci, ing, i);
            }
            if (Calories500(reci, ing))
            {
                return total;
            }
            return 0;
        }
        public static int Stat(int[] reci, int[,] ing, int stat)
        {
            int total = 0;

            for (int i = 0; i < 4; i++)
            {
                total += ing[i,stat] * reci[i];
                //Console.WriteLine(ing[i,stat] * reci[i]);
            }
            if (total < 0)
                total = 0;
            
            return total; 
        }
        public static bool Add(ref int[] reci)
        {
            int[] temp = reci;

            if (reci[1] == 100-(reci[2] + reci[3]))
            {
                reci[1] = 0;

                if (reci[2] == 100 - reci[3])
                {
                    reci[2] = 0;
                    
                    if (reci[3] == 100)
                    {
                        return false;
                    }

                    reci[3]++;
                }
                else
                {
                    reci[2]++;
                }
            }
            else
            {
                reci[1]++;
                reci[0]--;
                return true;
            }

            reci[0] = 100 - (reci[2] + reci[3]);
            return true;
        }
        public static void Main(string[] args)
        {
            Random random = new Random();

            int[,] ing = new int[,]
            {
            // cap dur fla tex
                {2, 0, -2, 0, 3},
                {0, 5, -3, 0, 3},
                {0, 0, 5, -1, 8},
                {0, -1, 0, 5, 8},

                {0, 1, 2, 3, -1}
            };

            int[] reci = new int[]
            {
                100,
                0,
                0,
                0
            };

            int high = 0;
            int count = 0;
            int temp;

            while (Add(ref reci))
            {
                count++;
                temp = Total(reci, ing);
                if (temp > high)
                {
                    high = temp;

                    using (StreamWriter sw = new StreamWriter("Found.txt", true))
                    {
                        sw.WriteLine(count + "\t" + reci[0] + " " + reci[1] + " " + reci[2] + " " + reci[3] + "  " + temp);
                    }
                }
                
                using (StreamWriter sw = new StreamWriter(reci[3] + "_Test.txt", true))
                {
                    sw.WriteLine(count + "\t" + reci[0] + " " + reci[1] + " " + reci[2] + " " + reci[3] + "  " + temp);
                }
            }
            
            Console.WriteLine("Done");







            /*
            int high = 0;
            string Name = "Tests.txt";
            
            while (1==1)
            {
                
                int low = 0;
                int count = 0;
                int offset = 0;
                int total;
                int temp;
                int temp2;
                int tempOffset = 0;
                string tempName = Name;
                while (count/1000000 + 1 < 25)
                {
                    count++;
                    offset = count/1000000 + 1;
                    if (tempOffset != offset)
                    {
                        Name = Convert.ToString(offset) + tempName;
                    }
                    tempOffset = offset;

                    
                    total = Total(reci, ing);

                    if (total == 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (Stat(reci, ing, i) == 0)
                            {
                                reci[ing[4,i]] += offset;
                                do
                                {
                                    temp = random.Next(0,4);
                                }
                                while(temp == i && reci[temp] != offset - 1);
                                reci[temp] -= offset;
                                break;
                            }
                        }
                    }
                    else
                    {
                        temp2 = Stat(reci, ing, 0);
                        low = 0;
                        for (int i = 1; i < 4; i++)
                        {
                            temp = Stat(reci, ing, i);
                            
                            if (temp < temp2)
                            {
                                temp2 = temp;
                                low = i;
                            }
                        }

                        reci[low] += offset;
                        do
                        {
                            temp = random.Next(0,4);
                        }
                        while(temp == low && reci[temp] != offset - 1);
                        reci[temp] -= offset;
                    }

                    if (total > high)
                    {
                        using (StreamWriter sw = new StreamWriter("Found.txt", true))
                        {
                            sw.Write(count + "\t");
                            for (int i = 0; i < 4; i++)
                            {
                                sw.Write(reci[i] + " ");
                            }
                            sw.Write(offset + " ");
                            sw.Write(total);
                            sw.WriteLine();
                        }
                        high = total;
                    }
                    
                    using (StreamWriter sw = new StreamWriter(Name, true))
                    {
                        sw.Write(count + "\t");
                        for (int i = 0; i < 4; i++)
                        {
                            sw.Write(reci[i] + " ");
                        }
                        sw.Write(offset + " ");
                        sw.Write(total);
                        sw.WriteLine();
                    }

                    
                    /*
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(reci[i]);
                    }
                    Console.WriteLine(total);
                    Console.ReadLine();
                    
                    
                }

                using (StreamWriter sw = new StreamWriter(Name, true))
                {
                    sw.WriteLine("RESET");
                }
                using (StreamWriter sw = new StreamWriter("Found.txt", true))
                {
                    sw.WriteLine("RESET");
                }

                tempName = Name;
                Name = "";
                for (int i = 2; i < tempName.Length; i++)
                {
                    Name += Convert.ToString(tempName[i]);
                }
                Name = "R" + Name;
                      
            }
            */ 
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;

namespace D16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int count = 0;
            string bin = "0";
            int total = 0;
            string temp;
            int num = 0;
            const int max = 150;
            string binary = "";
            int low = 100;
            int tempLow = 0;

            int[] val = new int[]
            {33,14,18,20,45,35,16,35,1,13,18,13,50,44,48,6,24,41,30,42};
            //{20, 15, 10, 5, 5};

            for (int i = 0; i < val.Length; i++)
            {
                binary += "1";
            }

            using (StreamWriter sw = new StreamWriter("Test.txt"))
            {
                sw.Write("");
            }

            while (bin != binary)
            {
                count++;
                num = 0;
                temp = Convert.ToString(count,2);
                tempLow = 0;
                bin = "";
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    bin += temp[i];
                }

                for (int i = 0; i < bin.Length; i++)
                {
                    if (bin[i] == '1')
                    {
                        num += val[i];
                        tempLow++;
                    }
                }

                if (tempLow < low && num == max)
                {
                    low = tempLow;
                    total = 0;
                }

                if (num == max && tempLow == low)
                {
                    total++;
                    using (StreamWriter sw = new StreamWriter("Test.txt", true))
                    {
                        sw.Write(num + " " + bin + " " + count + "\t");
                        
                        for (int i = 0; i < bin.Length; i++)
                        {
                            if (bin[i] == '1')
                            {
                                sw.Write(val[i] + " ");
                            }
                        }
                        sw.WriteLine();
                    }
                }

                
            }

            Console.WriteLine("TOTAL: " + total);
        }
    }
}
using System;
using System.IO;
using System.Reflection.Metadata;

namespace D20
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int a = 1;
            int b = 0;
            int jmp = 1;
            bool jmpReset = false;
            bool flag = true;
            int count = 0;
            const int insCount = 48;

            string[,] ins2 = new string[insCount,3];
            using (StreamReader sr = new StreamReader("ins.txt"))
            {
                for (int i = 0; i < insCount; i++)
                {
                    string[] temp = sr.ReadLine().Split(' ');
                    for (int j = 0; j < temp.Length; j++)
                    {
                        ins2[i,j] = temp[j];
                    }
                }
            }

            string[] ins = new string[3];
            do
            {
                ins[0] = ins2[count,0];
                ins[1] = ins2[count,1];
                ins[2] = ins2[count,2];
                
                if (ins[0] == "hlf")
                {
                    a /= 2;
                }
                else if (ins[0] == "tpl")
                {
                    a *= 3;
                }
                else if (ins[0] == "inc")
                {
                    if (ins[1] == "a")
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
                else if (ins[0] == "jmp")
                {
                    jmp = Convert.ToInt16(ins[1]);
                    jmpReset = true;
                }
                else if (ins[0] == "jio")
                {
                    if (a == 1)
                    {
                        jmp = Convert.ToInt16(ins[2]);
                        jmpReset = true;
                    }
                }
                else if (ins[0] == "jie")
                {
                    if (a % 2 == 0)
                    {
                        jmp = Convert.ToInt16(ins[2]);
                        jmpReset = true;
                    }
                }

                count += jmp;
                if (jmpReset)
                {
                    jmpReset = false;
                    jmp = 1;
                }

            }
            while(count < insCount);
            
            Console.WriteLine(b);
        }
    }
}
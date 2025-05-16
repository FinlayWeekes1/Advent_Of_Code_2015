using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Reflection.PortableExecutable;

namespace D7
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalN = 0;
            int totalC = 0;
            string code;

            using (StreamReader Code = new StreamReader("Codes.txt"))
            {
                do
                {
                    bool flag1 = false;
                    bool flag2 = false;
                    code = Code.ReadLine();
                    if (code == null)
                        break;

                    totalC += code.Length;
                    totalN += code.Length - 2;

                    for (int i = 2; i < code.Length-1; i++)
                    {
                        if (code[i-1] == '\\' && (code[i] == '\\' || code[i] == '\"'))
                        {
                            totalN--;
                        }
                        
                    }
                    for (int i = 4; i < code.Length-1; i++)
                    {
                        if (code[i-3] == '\\' && code[i-2] == 'x')
                        {
                            if (code[i-1] == 'a' || code[i-1] == 'b' || code[i-1] == 'c' || code[i-1] == 'd' || code[i-1] == 'e' || code[i-1] == 'f')
                            {
                                flag1 = true;
                            }
                            if (code[i] == 'a' || code[i] == 'b' || code[i] == 'c' || code[i] == 'd' || code[i] == 'e' || code[i] == 'f')
                            {
                                flag2 = true;
                            }
                            for (int j = 0; i < 10; i++)
                            {
                                if (code[i-1] == Convert.ToChar(j))
                                {
                                    flag1 = true;
                                }
                                if (code[i] == Convert.ToChar(j))
                                {
                                    flag2 = true;
                                }
                            }

                            if (flag1 && flag2)
                            {
                                totalN -= 3;
                            }
                        }
                    }


                }
                while(code != null);
            }

            Console.WriteLine(totalC-totalN);
        }
    }
}
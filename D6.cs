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

namespace D5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader Instructions = new StreamReader("Instructions.txt"))
            {
                string temp = "";
                string[] inst = new string[5];
                int[,] lights = new int[1000,1000];
                int state;

                // All lights start off
                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        lights[i,j] = 0;
                    }
                }
                
                do
                {
                    temp = Instructions.ReadLine();
                    if (temp == null)
                        break;
                    
                    inst = temp.Split(' ');

                    // Gets the state
                    if (inst[1] == "on")
                        state = 1;
                    else if (inst[1] == "off")
                        state = -1;
                    else
                        state = 2;

                    // Turns off or on depending on state
                    if (state != 2)
                    {
                        for (int i = Convert.ToInt32(((inst[2]).Split(','))[0]); i < Convert.ToInt32(((inst[4]).Split(','))[0])+1; i++)
                        {
                            for (int j = Convert.ToInt32(((inst[2]).Split(','))[1]); j < Convert.ToInt32(((inst[4]).Split(','))[1])+1; j++)
                            {
                                lights[i,j] += state;
                                
                                // Minimum of 0
                                if (lights[i,j] < 0)
                                {
                                    lights[i,j] = 0;
                                }
                            }
                            
                        }
                    }
                    // Toggles
                    else
                    {
                        for (int i = Convert.ToInt32(((inst[1]).Split(','))[0]); i < Convert.ToInt32(((inst[3]).Split(','))[0])+1; i++)
                        {
                            for (int j = Convert.ToInt32(((inst[1]).Split(','))[1]); j < Convert.ToInt32(((inst[3]).Split(','))[1])+1; j++)
                            {
                                lights[i,j] += state;
                            }
                        }
                    }
                }
                while(temp != null);
                
                // Counts the number on
                int total = 0;
                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        total += lights[i,j];
                    }
                }

                Console.WriteLine(total);
            }
        }
    }
}
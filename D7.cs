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

namespace D7
{
    class Program
    {
        public static void Set(string[,] vars, int i, string assign)
        {
            vars[i,1] = ".";
            vars[i,2] = ".";
            vars[i,3] = ".";
            vars[i,4] = assign;
            vars[i,5] = ".";
            Console.WriteLine("SETTING " + vars[i,0] + " TO " + assign);
        }
        public static int Find(string[,] vars, int varNum, string var)
        {
            for (int i = 0; i < varNum; i++)
            {
                if (vars[i,0] == var)
                {
                    return i;
                }
            }

            return varNum;
        }
        public static void Display(string[,] vars, int varNum)
        {
            for (int i = 0; i < varNum; i++)
            {
                Console.WriteLine(vars[i,0] + " " + vars[i,1] + " " + vars[i,2] + " " + vars[i,3] + " " + vars[i,4] + " " + vars[i,5]);
            }
        }
        public static bool IsInt(string num)
        {
            try
            {
                int temp2 = Convert.ToInt16(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string Binary(string num)
        {
            return Convert.ToString(Convert.ToInt16(num) & 0xFFFF, 2).PadLeft(16, '0');
        }
        public static string NOT(string num)
        {
            string numN = "";

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '0')
                    numN += '1';
                else
                    numN += '0';
            }

            return numN;
        }
        public static string AND(string num1, string num2)
        {
            string numA = "";
            
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] == '1' && num2[i] == '1')
                    numA += '1';
                else
                    numA += '0';
            }

            return numA;
        }
        public static string OR(string num1, string num2)
        {
            string numR = "";
            
            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] == '1' || num2[i] == '1')
                    numR += '1';
                else
                    numR += '0';
            }

            return numR;
        }
        public static string RSHIFT(string num, string temp)
        {
            int shift = Convert.ToInt16(temp);
            string numR = "";

            for (int i = 0; i < shift; i++)
            {
                numR += '0';
            }

            for (int i = 0; i < num.Length - shift; i++)
            {
                numR += num[i];
            }

            return numR;
        }
        public static string LSHIFT(string num, string temp)
        {
            int shift = Convert.ToInt16(temp);
            string numL = "";

            for (int i = shift; i < num.Length; i++)
            {
                numL += num[i];
            }
            
            for (int i = 0; i < shift; i++)
            {
                numL += '0';
            }

            return numL;
        }
        static void Main(string[] args)
        {
            // Gets the number of variables
            int varNum = 0;
            using (StreamReader Ins = new StreamReader("Instructions.txt"))
            {
                do
                {
                    string inst = Ins.ReadLine();
                    if (inst == null)
                        break;
                    varNum++;
                    
                }
                while(Ins != null);
            }
            
            string[,] vars = new string[varNum+1,6];
            
            // Fills vars with "."
            for (int i = 0; i < varNum; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    vars[i,j] = ".";
                }
            }

            // Fills vars with data:
            // vars[x,0] unique for each variable
            // vars[x,1 and 3] are for the two varaible which opperate on each other to create vars[x,0]
            // vars[x,2] is the method which variables use to create vars[x,0]
            // vars[x,4] the number that is equal to vars[x,0]
            // vars[x,5] is the variable which is equal to vars[x,0] (lx -> a)
            // vars[x,3] is "." with a NOT
            // all other spaces are "."
            using (StreamReader Ins = new StreamReader("Instructions.txt"))
            {
                int count = 0;
                do
                {
                    string temp = Ins.ReadLine();
                    if (temp == null)
                        break;
                    
                    string[] inst = new string[5];
                    inst = temp.Split(' ');

                    // Assignment
                    if (inst[1] == "->")
                    {
                        if (IsInt(inst[0]) == true)
                        {
                            vars[count,4] = Binary(inst[0]);
                        }
                        else
                        {
                            vars[count,5] = inst[0];
                        }
                        
                        vars[count,0] = inst[2];
                    }
                    // NOT
                    else if (inst[2] == "->")
                    {
                        vars[count,2] = inst[0];
                        vars[count,1] = inst[1];
                        vars[count,0] = inst[3];
                    }
                    // AND OR LSHIFT RSHIFT
                    else if (inst[3] == "->")
                    {
                        vars[count,0] = inst[4];
                        vars[count,2] = inst[1];
                        vars[count,3] = inst[2];
                        
                        if (IsInt(inst[0]) == true)
                            vars[count,1] = Binary(inst[0]);
                        else
                            vars[count,1] = inst[0];
                    }
                    count++;
                }
                while(Ins != null);
            }
            
            int loop = 0;
            

            // Finds a by repeating the list and calculating what it can
            while(vars[Find(vars, varNum, "a"),4] == ".")
            {
                Display(vars, varNum);
                for (int i = 0; i < varNum; i++)
                {
                    // If it isnt already calculated
                    if (vars[i,4] == ".")
                    {
                        // Sets it to the variable it is if it can
                        if (vars[i,5] != ".")
                        {
                            if (vars[Find(vars, varNum, vars[i,5]),4] != ".")
                            {
                                Set(vars, i, vars[Find(vars, varNum, vars[i,5]),4]);
                            }
                        }
                        // NOT
                        else if (vars[i,2] == "NOT")
                        {
                            if (vars[Find(vars, varNum, vars[i,1]),4] != ".")
                            {
                                Set(vars, i, NOT(vars[Find(vars, varNum, vars[i,1]),4]));
                            }
                        }
                        // AND and OR
                        else if (vars[i,2] == "AND" || vars[i,2] == "OR")
                        {
                            if (IsInt(vars[i,1]) == true && vars[Find(vars, varNum, vars[i,3]),4] != ".")
                            {
                                if (vars[i,2] == "AND")
                                {
                                    Set(vars, i, AND(vars[i,1], vars[Find(vars, varNum, vars[i,3]),4]));
                                }
                                else
                                {
                                    Set(vars, i, OR(vars[i,1], vars[Find(vars, varNum, vars[i,3]),4]));
                                }
                            }
                            else if (vars[Find(vars, varNum, vars[i,1]),4] != "." && vars[Find(vars, varNum, vars[i,3]),4] != ".")
                            {
                                if (vars[i,2] == "AND")
                                {
                                    Set(vars, i, AND(vars[Find(vars, varNum, vars[i,1]),4], vars[Find(vars, varNum, vars[i,3]),4]));
                                }
                                else
                                {
                                    Set(vars, i, OR(vars[Find(vars, varNum, vars[i,1]),4], vars[Find(vars, varNum, vars[i,3]),4]));
                                }
                            }
                        }
                        // RSHIFT and LSHIFT
                        else if (vars[i,2] == "LSHIFT" || vars[i,2] == "RSHIFT")
                        {
                            if (vars[Find(vars, varNum, vars[i,1]),4] != ".")
                            {
                                if (vars[i,2] == "LSHIFT")
                                {
                                    Set(vars, i, LSHIFT(vars[Find(vars, varNum, vars[i,1]),4], vars[i,3]));
                                }
                                else
                                {
                                    Set(vars, i, RSHIFT(vars[Find(vars, varNum, vars[i,1]),4], vars[i,3]));
                                }
                            }
                        }
                    }
                }

                loop++;
                Console.WriteLine("LOOP " + loop);
                //Console.ReadLine();
            }

            Console.WriteLine(vars[Find(vars, varNum, "a"),4]);
        }
    }
}
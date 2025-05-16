using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Globalization;
using System.IO.Pipes;

namespace D11
{
    class Program
    {
        public static void Display(string[,,] dinner,int row)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write(dinner[j,row,i]);
                }
                Console.WriteLine();
            }
        }
        public static bool Add(ref string[,,] dinner, int table, ref int num)
        {
            int num1 = 0;
            int num2 = 0;
            int count = 0;
            num++;

            for (int i = 0; i < 8; i++)
            {
                if (dinner[table,3,i] == "1" && count == 0)
                {
                    num1 = i;
                    count++;
                }
                else if (count == 1 && dinner[table,3,i] == "1")
                {
                    num2 = i;
                }
            }

            dinner[table,3,num1] = "0";
            dinner[table,3,num2] = "0";

            if (num1 == 6 && num2 == 7)
            {
                num1 = 0;
                num2 = 1;
                if (table == 4)
                {
                    if (Add(ref dinner, table + 1, ref num) == false)
                    {
                        dinner[table,3,num1] = "1";
                        dinner[table,3,num2] = "1";
                        return Check(ref dinner, ref num);
                    }
                }
                else
                {
                    dinner[table,3,num1] = "1";
                    dinner[table,3,num2] = "1";
                    return Check(ref dinner, ref num);
                }
            }
            else
            {
                if (num1 == num2 - 1)
                {
                    num2++;
                    num1 = 0;
                }
                else
                {
                    num1++;
                }
            }

            dinner[table,3,num1] = "1";
            dinner[table,3,num2] = "1";

            return Check(ref dinner, ref num);
        }
        public static bool Check(ref string[,,] dinner, ref int num)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (dinner[i,3,j] == "1" && dinner[i,3,j] == ".")
                    {
                        Display(dinner, 3);
                        Console.ReadLine();
                        return Add(ref dinner, i, ref num);
                    }
                }
            }
            return true;
        }
        public static void Main(string[] args)
        {
            string[,,] dinner = new string[,,]
            {
                {
                    {"Alice", "Alice", "Alice", "Alice", "Alice", "Alice", "Alice", "Alice"},
                    {".", "2", "26", "-82", "-75", "42", "38", "39"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"0", "1", "1", "0", "0", "0", "0", "0"}
                },

                {
                    {"Bob", "Bob", "Bob", "Bob", "Bob", "Bob", "Bob", "Bob"},
                    {"40", ".", "-61", "-15", "63", "41", "30", "87"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "0", "1", "0", "0", "0", "0", "0"}
                },

                {
                    {"Carol", "Carol", "Carol", "Carol", "Carol", "Carol", "Carol", "Carol"},
                    {"-35", "-99", ".", "-51", "95", "90", "-16", "94"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "1", "0", "0", "0", "0", "0", "0"}
                },

                {
                    {"David", "David", "David", "David", "David", "David", "David", "David"},
                    {"36", "-18", "-65", ".", "-18", "-22", "2", "42"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "1", "0", "0", "0", "0", "0", "0"}
                },

                {
                    {"Eric", "Eric", "Eric", "Eric", "Eric", "Eric", "Eric", "Eric"},
                    {"-65", "24", "100", "51", ".", "21", "55", "44"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "1", "0", "0", "0", "0", "0", "0"}
                },

                {
                    {"Frank", "Frank", "Frank", "Frank", "Frank", "Frank", "Frank", "Frank"},
                    {"-48", "91", "8", "-66", "97", ".", "-9", "-92"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "1", "0", "0", "0", "0", "0", "0"}
                },

                {
                    {"George", "George", "George", "George", "George", "George", "George", "George"},
                    {"-44", "-25", "17", "92", "-92", "18", ".", "97"},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "1", "0", "0", "0", "0", "0", "0"}
                },

                {
                    {"Temp", "Temp", "Temp", "Temp", "Temp", "Temp", "Temp", "Temp"},
                    {"92", "-96", "-51", "-81", "31", "-73", "-89", "."},
                    {"Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory"},
                    {"1", "1", "0", "0", "0", "0", "0", "0"}
                },
            };

            int num = 0;
    
            while (Add(ref dinner, 0, ref num) == true)
            {
                if (num % 100000 == 0)
                {
                    Console.WriteLine(num);
                    Display(dinner, 3);
                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
            Console.WriteLine(num);
            Display(dinner, 3);
            Console.WriteLine();
            Console.ReadLine();


        }
    }
}
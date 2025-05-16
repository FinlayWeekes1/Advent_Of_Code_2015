using System;
using System.IO;
using System.Runtime.Serialization;

namespace D16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] mySue = new string[,]
            {
                {"3", "7", "2", "3", "0", "0", "5", "3", "2", "1"},
                {"children:", "cats:", "samoyeds:", "pomeranians:", "akitas:", "vizslas:", "goldfish:", "trees:", "cars:", "perfumes:"}
            };

            bool flag;
            int count = 0;
            string temp = "";
            using (StreamReader sr = new StreamReader("Sues.txt"))
            {
                do
                {
                    temp = sr.ReadLine();
                    if (temp == null)
                        break;

                    count++;
                    string[] sue = temp.Split(' ');
                    flag = false;
                    //Console.WriteLine(sue[1]);

                    for (int i = 2; i < 8; i += 2)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (sue[i] == mySue[1,j])
                            {
                                if (i == 6)
                                {
                                    sue[i+1] += ",";
                                }

                                if (sue[i+1].Length == 3)
                                {
                                    sue[i+1] = "10";
                                }
                                else
                                {
                                    sue[i+1] = Convert.ToString(sue[i+1][0]);
                                }

                                if (j == 1 || j == 7)
                                {
                                    if (int.Parse(sue[i+1]) > int.Parse(mySue[0,j]))
                                    {
                                        break;
                                    }
                                    else 
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                else if (j == 3 || j == 6)
                                {
                                    if (int.Parse(sue[i+1]) < int.Parse(mySue[0,j]))
                                    {
                                        break;
                                    }
                                    else 
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (sue[i+1] == mySue[0,j])
                                    {
                                        break;
                                    }
                                    else 
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                
                            }
                           
                        }

                        if (flag)
                        {
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        Console.WriteLine("FOUND" + " " + sue[1]);
                        break;
                    }
                }
                while (temp != null);
            }
        }
    }
}
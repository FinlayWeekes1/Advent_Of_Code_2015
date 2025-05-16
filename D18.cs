using System;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace D18
{
    public class Program
    {
        public static void Display(string[,] board, int length, int lengthx)
        {
            string B = "";
            for (int i = 1; i < length+1; i++)
            {
                for (int j = 1; j < lengthx+1; j++)
                {
                    B += board[i,j];
                }
                B += "\x1b[49m\n";
            }
            Console.WriteLine(B);
        }
        public static int Neighbours(string[,] board, int y, int x)
        {
            int total = 0;
            if (board[y,x] == "\x1b[47m ")
            {
                total = -1;
            }

            for (int i = x-1; i < x+2; i++)
            {
                for (int j = y-1; j < y+2; j++)
                {
                    if (board[j,i] == "\x1b[47m ")
                        total++;
                }
            }

            return total;
        }
        public static void Main(string[] args)
        {
            string temp = "";
            int count = 0; 
            int length = 0;
            int lengthx = 0;

            using (StreamReader sr = new StreamReader("Board.txt"))
            {
                lengthx = sr.ReadLine().Length;
            }

            using (StreamReader sr = new StreamReader("Board.txt"))
            {
                do 
                {
                    temp = sr.ReadLine();
                    if (temp == null)
                        break;
                    length++;
                }
                while (temp != null);
            }
            string[,] board = new string[length+2, lengthx+2];

            using (StreamReader sr = new StreamReader("Board.txt"))
            {
                do
                {
                    count++;
                    temp = sr.ReadLine();
                    if (temp == null)
                        break;

                    for (int i = 1; i < lengthx+1; i++)
                    {
                        if (Convert.ToString(temp[i-1]) == "#")
                        {
                            board[count,i] = "\x1b[47m ";
                        }
                        else
                        {
                            board[count,i] = "\x1b[40m ";
                        }
                    }
                }
                while(temp != null);
            }

            for (int i = 0; i < lengthx+3; i+= lengthx+1)
            {
                for (int j = 0; j < length+2; j++)
                {
                    board[j,i] = "\x1b[40m "; 
                }
            }
            for (int i = 0; i < length+3; i+=length+1)
            {
                for (int j = 0; j < lengthx+2; j++)
                {
                    board[i,j] = "\x1b[40m "; 
                }
            }
            Display(board, length, lengthx);
            Console.WriteLine();

            string[,] tempB = new string[length+2, lengthx+2];
            for (int i = 0; i < length+2; i++)
            {
                for (int j = 0; j < lengthx+2; j++)
                {
                    tempB[i,j] = board[i,j];
                }
            }

            int ns;

            for (count = 0; count < 1000000; count++)
            {
                for (int i = 1; i < length+1; i++)
                {
                    for (int j = 1; j < lengthx+1; j++)
                    {
                        ns = Neighbours(board, i, j);

                        if (board[i,j] == "\x1b[47m ")
                        {
                            if (ns != 3 && ns != 2)
                            {
                                tempB[i,j] = "\x1b[40m ";
                            }
                        }
                        else
                        {
                            if (ns == 3)
                            {
                                tempB[i,j] = "\x1b[47m ";
                            }
                        }
                    }
                    //Display(tempB, length);
                    //Console.ReadLine();
                } 

                for (int i = 0; i < length+2; i++)
                {
                    for (int j = 0; j < lengthx+2; j++)
                    {
                        board[i,j] = tempB[i,j];
                    }
                }

                Display(board, length, lengthx);
                
                Thread.Sleep(100);
                //Console.WriteLine(count);
                //Console.ReadLine();

            }

            int total = 0;
            for (int i = 1; i < length+1; i++)
            {
                for (int j = 1; j < lengthx+1; j++)
                {
                    if (board[i,j] == "\x1b[47m ")
                    {
                        total++;
                    }
                }
            }
            //Console.WriteLine();
            //onsole.WriteLine(total);
        }
    }
}
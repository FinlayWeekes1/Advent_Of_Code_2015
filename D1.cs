using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string input;
        using (StreamReader sr = new StreamReader("input.txt"))
        {
            input = sr.ReadLine();
        }
        
        int ins = 0;
        int floor = 0;
        while (floor != -1)
        {
            if (input[ins] == '(')
            {
                floor++;
            }
            else
            {
                floor--;
            }
            ins++;
        }
        Console.WriteLine(ins);
    }
}
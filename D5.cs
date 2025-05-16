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
            using (StreamReader Word = new StreamReader("Words.txt"))
            {
                bool pairPair = false;
                bool twoL = false;
                int total = 0;
                string word = "";
                do
                {
                    word = Word.ReadLine();
                    if (word == null)
                        break;

                    pairPair = false;
                    twoL = false;

                    // Check for doubles with gap
                    for (int i = 2; i < word.Length; i++)
                    {
                        if (word[i] == word[i-2])
                            twoL = true;
                    }

                    // Checks for pair of pairs
                    for (int i = 1; i< word.Length; i++)
                    {
                        for (int j = 1; j < word.Length; j++)
                        {
                            if (j >= i+2 || j <= i-2)
                            {
                                if (word[i] == word[j] && word[i-1] == word[j-1])
                                    pairPair = true;
                            }
                        }
                    }

                    // Adds to total
                    if (twoL == true && pairPair == true)   
                        total++;
                    
                }
                while(word != null);

                Console.WriteLine(total);
            }
        }
    }
}

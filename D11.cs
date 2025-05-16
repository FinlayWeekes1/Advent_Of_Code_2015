using System;
using System.IO;
using System.Threading;
using System.Text;

namespace D11
{
    class Program
    {
        public static bool Check(string pass)
        {
            // Cannot contin i o or l
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] == 'i' || pass[i] == 'o' || pass[i] == 'l')
                {
                    return false;
                }
            }

            // Contains each pair of letters
            string[] Tpass = new string[7];
            for (int i = 1; i < pass.Length; i++)
            {
                Tpass[i-1] = Convert.ToString(pass[i-1]);
                Tpass[i-1] += Convert.ToChar(pass[i]);
            }
            
            // at least two non overlapping pairs
            int temp = 0;
            for (int i = 0; i < Tpass.Length; i++)
            {
                if (Tpass[i][0] == Tpass[i][1])
                {
                    temp++;
                    i++;
                }
            }
            if (temp >= 2)
            {
                // Triplets of passowrd
                string[] Thpass = new string[6];
                for (int i = 2; i < pass.Length; i++)
                {
                    Thpass[i-2] = Convert.ToString(pass[i-2]);
                    Thpass[i-2] += Convert.ToChar(pass[i-1]);
                    Thpass[i-2] += Convert.ToChar(pass[i]);
                }

                // Each 3 letter ting in the alphabet
                string[] alpha = new string[]
                {"abc", "bcd", "cde", "def", "efg", "fgh", "ghi", "hij", "ijk", "jkl", "klm", "lmn", "mno", "nop", "opq", "pqr", "qrs", "rst", "stu", "tuv", "uvw", "vwx", "wxy", "xyz"};
                
                for (int i = 0; i < alpha.Length; i++)
                {
                    for (int j = 0; j < Thpass.Length; j++)
                    {
                        if (alpha[i] == Thpass[j])
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static string Increment(ref string pass)
        {
            string[] newPass = new string[pass.Length];
            int am = -1;
            char next;

            // Alphabet with no l i or o
            char[] alpha = new char[]
            {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            
            for (int i = pass.Length-1; i >=0; i--)
            {
                next = '.';
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (pass[i] == alpha[alpha.Length-1])
                    {
                        am++;
                        break;
                    }
                    else if(pass[i] == alpha[j])
                    {
                        next = alpha[j+1];
                    }
                }
                if (next != '.')
                {
                    for (int j = 0; j < pass.Length; j++)
                    {
                        newPass[j] = Convert.ToString(pass[j]);
                    }

                    if (am != -1)
                    {
                        for (int j = pass.Length-1; j >= pass.Length-1-am; j--)
                        {
                            newPass[j] = Convert.ToString(alpha[0]);
                        }
                    }

                    newPass[newPass.Length-2-am] = Convert.ToString(next);
                    //Console.WriteLine(next)

                    pass = "";
                    for (int j = 0; j < newPass.Length; j++)
                    {
                        pass += newPass[j];
                    }
                    
                    return pass;
                }
            }

            using (StreamWriter sw = new StreamWriter("ERROR.txt"))
            {
                sw.WriteLine("Cant increment {0}", pass);
            }

            return "aaaaaaaa";
        }
        public static void Main(string[] args)
        {
            string pass = "cqjxxyzz";
            while (Check(Increment(ref pass)) == false)
            {

            };

            Console.WriteLine(pass);
        }
    }
}
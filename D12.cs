using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Globalization;

namespace D11
{
    class Program
    {
        public static void Main(string[] args)
        {
            string storage = "";
            int num = 0;
            bool found = false;
            double total = 0;
            string temp = "";

            int lastO= 1;
            int Oinbetween = 0;
            int countC = 0;
            int countO = 0;
            List<List<int>> ignore = new List<List<int>>();

            using (StreamReader sr = new StreamReader("Storage.txt"))
            {
                storage = sr.ReadLine();
            }

            for (int i = 0; i < storage.Length; i++)
            {
                if (storage[i] == '{')
                {
                    countO++;
                }
                else if (storage[i] == '}')
                {
                    countC++;
                }
            }
            int[,] open = new int[countO,2];
            int[,] close = new int[countC,2];
            countO = -1;
            countC = -1;
            for (int i = 0; i < storage.Length; i++)
            {
                if (storage[i] == '{')
                {
                    countO++;
                    open[countO,0] = i;
                    open[countO,1] = 0;
                }
                else if (storage[i] == '}')
                {
                    countC++;
                    close[countC,0] = i;
                    close[countC,1] = 0;
                }
            }
            
            countC = -1;
            countO = -1;
            for (int i = 2; i < storage.Length; i++)
            {
                if (storage[i] == '}')
                {
                    countO++;
                }
                if (storage[i] == '}' && found == true && countO != 0)
                {
                    countC++;
                }
                if (storage[i] == '{' && found == true)
                {
                    countC--;
                }
                if (storage[i] == '}' && found == true && countO == 0)
                {
                    close[countO,1] = 1;
                    countC = -1;
                    found = false;
                }
                if (storage[i] == 'd' && storage[i-1] == 'e' && storage[i-2] == 'r')
                {
                    found = true;
                }
            }

            countC = -1;
            countO = -1;
            for (int i = storage.Length-3; i >= 0; i--)
            {
                if (storage[i] == '{')
                {
                    countO++;
                }
                if (storage[i] == '{' && found == true && countO != 0)
                {
                    countC++;
                }
                if (storage[i] == '}' && found == true)
                {
                    countC--;
                }
                if (storage[i] == '{' && found == true && countO == 0)
                {
                    open[countO,1] = 1;
                    countC = -1;
                    found = false;
                }
                if (storage[i+2] == 'd' && storage[i+1] == 'e' && storage[i] == 'r')
                {
                    found = true;
                }
            }

            countC = -1;
            countO = -1;
            for (int i = 0; i < storage.Length; i++)
            {
                if (storage[i] == '{')
                {
                    countO++;
                }
                if (storage[i] == '}')
                {
                    countC++;
                }

                if (storage[i] == '{')
                {
                    if (open[countO,1] == 1)
                    {
                        while(close[countO,1] == 0)
                        {
                            countO++;
                            i++;
                            if (storage[i] == '{')
                            {
                                countO++;
                            }
                            if (storage[i] == '}')
                            {
                                countC++;
                            }
                        }
                        i = close[countO,0];
                    }
                }

                found = false;
                if (storage[i] == '-' || storage[i] == '1' || storage[i] == '2' || storage[i] == '3' || storage[i] == '4' || storage[i] == '5' || storage[i] == '6' || storage[i] == '7' || storage[i] == '8' || storage[i] == '9' || storage[i] == '0')
                {
                    found = true;
                }

                if (found)
                {
                    num++;
                }
                else
                {
                    if (num > 0)
                    {
                        temp = "";
                        for (int j = i-num; j < i; j++)
                        {
                            //Console.WriteLine(storage[j]);
                            temp += Convert.ToString(storage[j]);
                        }
                        
                        total += Convert.ToDouble(temp);
                        num = 0;
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}
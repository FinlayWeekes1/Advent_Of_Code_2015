using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace D20
{
    internal class Program
    {
        public static int X(int n)
        {
            return Convert.ToInt32((n+1)*(n+1)*0.5-0.5*(n+1));
        }
        public static int Y(int n, int x)
        {
            int num = X(x);
            for (int i = x; i < n+x-1; i++)
            {
                num += i;
            }
            return num;
        }
        static void Main(string[] args)
        {
            int tries = Y(2978, 3083);
            //int tries = 2;
            Int128 num = 20151125;
            //Console.WriteLine(Y(2978, 3083));

            for (int i = 1; i < tries; i++)
            {
                num = (num*252533)%33554393;
            }
            Console.WriteLine(num);
        }
    }
}
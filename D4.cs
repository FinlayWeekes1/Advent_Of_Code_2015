using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace D20
{
    internal class Program
    {
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
        static void Main(string[] args)
        {
            const string input = "bgvyzdsv";
            int num = 1;
            string md5;

            do
            {
                md5 = GetMd5Hash(input + Convert.ToString(num));
                Console.WriteLine(md5);
                if (md5[0] == '0' && md5[1] == '0' && md5[2] == '0' && md5[3] == '0' && md5[4] == '0' && md5[5] == '0')
                {
                    Console.WriteLine(num);
                    Console.ReadLine();
                }
                num++;
            }
            while(1 == 1); 

            
        }
    }
}
using System;
using System.IO;

namespace D20
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const int mainHouse = 29000000;
            int mainPresents = 0;
            for (int i = 1; i < mainHouse+1; i++)
            {
                if (mainHouse % i == 0)
                {
                    mainPresents += i;
                }
            }

            int[] houses = new int[16000000];
            for (int i = 0; i < houses.Length; i++)
            {
                houses[i] = 0;
            }

            for (int elf = 1; elf < houses.Length; elf++)
            {
                for (int house = 1; house < houses.Length; house++)
                {
                    if (elf % house == 0)
                    {
                        houses[house] += elf;
                    }
                }
                Console.WriteLine(elf);
            }

            for (int i = 0; i < houses.Length; i++)
            {
                if (houses[i] > mainHouse)
                {
                    Console.WriteLine("FOUND: {0}, {1}", i, houses[i]);
                    break;
                }
            }
        }
    }
}
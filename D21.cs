using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace D20
{
    public static class Program
    {
        public static bool Fight(int bossA, int bossD, int bossH, int playA, int playD, int playH)
        {
            bossD = bossD-playA;
            if (bossD < 1)
                bossD = 1;

            playD = playD-bossA;
            if (playD < 1)
                playD = 1;

            while(playH > 0)
            {
                bossH -= playD;
                //Console.WriteLine("{0} Boss {1}", bossH, playD);

                if (bossH <= 0)
                    return true;
                
                playH -= bossD;
                //Console.WriteLine("{0} Play {1}", playH, bossD);
            }
            return false;
        }
        public static void Main(string[] args)
        {
            /*
            Weapons:    Cost  Damage  Armor
            Dagger        8     4       0
            Shortsword   10     5       0
            Warhammer    25     6       0
            Longsword    40     7       0
            Greataxe     74     8       0

            Armor:      Cost  Damage  Armor
            Leather      13     0       1
            Chainmail    31     0       2
            Splintmail   53     0       3
            Bandedmail   75     0       4
            Platemail   102     0       5

            Rings:      Cost  Damage  Armor
            Damage +1    25     1       0
            Damage +2    50     2       0
            Damage +3   100     3       0
            Defense +1   20     0       1
            Defense +2   40     0       2
            Defense +3   80     0       3
            */
            
            const int bossA = 2;
            const int bossD = 8;
            const int bossH = 100;
            const int playH = 100;

            int[] dmg = new int[13];
            dmg[0] = 11;

            int count = 0;
            for (int d = 1; d < 13; d++)
            {
                count = 0;
                while(! Fight(bossA, bossD, bossH, count, d, playH))
                {
                    //Console.WriteLine(count);
                    //Console.ReadLine();
                    count++;
                }
                //Console.WriteLine("true: {0}dmg {1}amr", d, count);
                //Console.ReadLine();
                dmg[d] = count;
            }

            int[] amr = new int[11];

            for (int a = 0; a < 11; a++)
            {
                count = 0;
                while(! Fight(bossA, bossD, bossH, a, count, playH))
                {
                    //Console.WriteLine(count);
                    //Console.ReadLine();
                    count++;
                }
                //Console.WriteLine("true: {0}amr {1}dmg", a, count);
                //Console.ReadLine();
                amr[a] = count;
            }

            for (int d = 0; d < dmg.Length; d++)
            {
                Console.WriteLine("{0}dmg needs at least {1}amr", d, dmg[d]);
            }
            Console.WriteLine();
            for (int a = 0; a < amr.Length; a++)
            {
                Console.WriteLine("{0}amr needs at least {1}dmg", a, amr[a]);
            }

            for (int d = 0; d < dmg.Length; d++)
            {

            }
        }
    }
}
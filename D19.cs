using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace D19
{
    public class Program
    {
        public static void Set(string mol, ref string[] mol1, ref string[] mol2)
        {
            for(int i = 0; i < mol.Length; i++)
            {
                mol1[i] = Convert.ToString(mol[i]);
            }
            for (int i = 0; i < mol.Length-1; i++)
            {
                mol2[i] = Convert.ToString(mol[i]) + Convert.ToString(mol[i+1]);
            }
        }
        public static string Compile1(string[] mol1)
        {
            string newMol = "";

            for (int i = 0; i < mol1.Length; i++)
            {
                newMol += mol1[i];
            }

            return newMol;
        }
        public static string Compile2(string[] mol2, string[] mol1, int index)
        {
            mol1[index] = mol2[index];
            if (index != mol1.Length-1)
                mol1[index+1] = "";

            return Compile1(mol1);
        }
        public static void Main(string[] args)
        {
            string temp;
            using (StreamReader sr = new StreamReader("Mol.txt"))
            {
                temp = sr.ReadLine();
            }
            string[] mol1 = new string[temp.Length];
            string[] mol2 = new string[temp.Length-1];
            string mol = temp;

            for(int i = 0; i < temp.Length; i++)
            {
                mol1[i] = Convert.ToString(temp[i]);
            }
            for (int i = 0; i < temp.Length-1; i++)
            {
                mol2[i] = Convert.ToString(temp[i]) + Convert.ToString(temp[i+1]);
            }

            int is1 = 0;
            int is2 = 0;
            int count = 0;
            
            using (StreamReader sr = new StreamReader("Ins.txt"))
            {
                do 
                {
                    temp = sr.ReadLine();
                    if (temp == null)
                        break;

                    count++;
                    if (temp.Split(' ')[0].Length > 1)
                    {
                        is2++;
                    }
                    else
                    {
                        is1++;
                    }
                }
                while (temp != null);

            }

            string[,] ins1 = new string[is1, 2];
            string[,] ins2 = new string[is2, 2];
            int tempNum = 0;
            
            using (StreamReader sr = new StreamReader("Ins.txt"))
            {
                for (int i = 0; i < count; i++)
                {
                    temp = sr.ReadLine();
                    for (int j = 0; j < 2; j++)
                    {   
                        if (temp.Split(' ')[0].Length == 1)
                        {
                            ins1[tempNum,j] = temp.Split(' ')[j];
                            if (j == 1)
                                tempNum++;
                        }
                    }
                }
            }
            tempNum = 0;
            using (StreamReader sr = new StreamReader("Ins.txt"))
            {
                for (int i = 0; i < count; i++)
                {
                    temp = sr.ReadLine();
                    for (int j = 0; j < 2; j++)
                    {   
                        if (temp.Split(' ')[0].Length > 1)
                        {
                            ins2[tempNum,j] = temp.Split(' ')[j];
                            if (j == 1)
                                tempNum++;
                        }
                    }
                }
            }

            List<string> mols = new List<string>();
            string[] tempMol1 = new string[mol1.Length];
            string[] tempMol2 = new string[mol2.Length];
            string tempMol;

            for(int i = 0; i < mol1.Length; i++)
            {
                for (int j = 0; j < is1; j++)
                {
                    Set(mol, ref mol1, ref mol2);
                    if (mol1[i] == ins1[j,0])
                    {
                        for (int l = 0; l < mol1.Length; l++)
                        {
                            tempMol1[l] = mol1[l];
                        }

                        //Console.WriteLine("tempMol1: " + Compile1(tempMol1));
                        tempMol1[i] = ins1[j,1];
                        //Console.WriteLine(ins1[j,1]);
                        tempMol = Compile1(tempMol1);
                        
                        if (mols.Contains(tempMol) == false)
                        {
                            mols.Add(tempMol);
                            Console.WriteLine(tempMol);
                        }
                    }
                }
            }
            Console.WriteLine(mols.Count());

            for(int i = 0; i < mol2.Length; i++)
            {
                for (int j = 0; j < is2; j++)
                {
                    Set(mol, ref mol1, ref mol2);
                    //Console.WriteLine("mol2: " + mol2[0] + mol2[1] + mol2[2]);
                    if (mol2[i] == ins2[j,0])
                    {
                        for (int l = 0; l < mol2.Length; l++)
                        {
                            tempMol2[l] = mol2[l];
                        }
                        //Console.WriteLine("mol2: " + tempMol2[0] + tempMol2[1] + tempMol2[2]);
                        //Console.WriteLine("mol1: " + mol1[0] + mol1[1] + mol1[2] + mol1[3]);
                        tempMol2[i] = ins2[j,1];
                        //Console.WriteLine(tempMol2[0] + tempMol2[1] + tempMol2[2] + " " + ins2[j,1]);
                        tempMol = Compile2(tempMol2, mol1, i);
                        if (mols.Contains(tempMol) == false)
                        {
                            mols.Add(tempMol);
                            Console.WriteLine("ADDED: " + tempMol);
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine(mols.Count());
        }
    }
}
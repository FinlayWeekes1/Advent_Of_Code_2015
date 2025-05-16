using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Globalization;

namespace D2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("Dimensions.txt"))
            {
                Int64 total = 0;
                string temp;
                string[] temp2 = new string[3];
                int[] nums = new int[3];
                int[] nums2 = new int [3];
                int[] faces = new int[3];
                int low;
                int low2;
                int count = 0;
                do 
                {
                    
                    temp = sr.ReadLine();
                    if (temp == null)
                        break;
                    count++;
                    temp2 = temp.Split('x');

                    for (int i = 0; i < 3; i++)
                    {
                        nums[i] = Convert.ToInt32(temp2[i]);
                    }
                    Console.WriteLine(nums[0] + " " + nums[1] + " " + nums[2]);

                    
                    faces[0] = nums[0] * nums[1];
                    faces[1] = nums[0] * nums[2];
                    faces[2] = nums[1] * nums[2];

                    int volume = nums[0] * nums[1] * nums[2];

                    if (nums[0] < nums[1]) 
                    {
                        if (nums[0] < nums[2])
                            low = nums[0];
                        else
                            low = nums[2];
                    }
                    else if (nums[1] < nums[0])
                    {
                        if (nums[1] < nums[2])
                            low = nums[1];
                        else
                            low = nums[2];
                    }
                    else
                    {
                        if (nums[1] < nums[2])
                            low = nums[1];
                        else
                            low = nums[2];
                    }


                    if (nums[0] == low)
                    {
                        if (nums[1] < nums[2])
                            low2 = nums[1];
                        else
                            low2 = nums[2];
                    }
                    else if (nums[1] == low)
                    {
                        if (nums[0] < nums[2])
                            low2 = nums[0];
                        else
                            low2 = nums[2];
                    }
                    else
                    {
                        if (nums[1] < nums[0])
                            low2 = nums[1];
                        else
                            low2 = nums[0];
                    }

                    
                    int bow = low + low + low2 +low2;

                    Console.WriteLine(volume + " " + bow + "\n");

                    total += volume + bow;
                }
                while (temp != null);

                Console.WriteLine(total);
                Console.WriteLine(count);
            }
        }
    }
}

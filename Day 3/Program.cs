using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int count = 0;

            //Part 1
            foreach (string line in input)
            {
                for (int i = 0; i < line.Length - 4; i++)
                {
                    int num1 = 0;
                    int num2 = 0;
                    bool mul = false;
                    if (line.Substring(i,4) == "mul(")
                    {
                        string test = line.Substring(i+4,8);
                        for(int j = test.Length-1; j > 0; j--)
                        {
                            if (test[j] == ')' && Char.IsNumber(test[j-1]))
                            {
                                test = test.Substring(0,j);
                                string[] nums = test.Split(',');
                                num1 = int.Parse(nums[0]);
                                num2 = int.Parse(nums[1]);
                                mul = true;
                                break;
                            }
                        }
                    }
                    if(mul)
                    {
                        count += num1 * num2;
                    }
                }
            }

            Console.WriteLine("Part 1: " + count);

            //Part 2
            count = 0;
            bool doo = true;

            foreach (string line in input)
            {
                for (int i = 0; i < line.Length - 8; i++)
                {
                    if(line.Substring(i, 4) == "do()")
                    {
                        doo = true;
                    }
                    if(line.Substring(i, 7) == "don't()")
                    {
                        doo = false;
                    }


                    int num1 = 0;
                    int num2 = 0;
                    bool mul = false;
                    if (line.Substring(i, 4) == "mul(" && doo)
                    {
                        string test = line.Substring(i + 4, 8);
                        for (int j = test.Length - 1; j > 0; j--)
                        {
                            if (test[j] == ')' && Char.IsNumber(test[j - 1]))
                            {
                                test = test.Substring(0, j);
                                string[] nums = test.Split(',');
                                num1 = int.Parse(nums[0]);
                                num2 = int.Parse(nums[1]);
                                mul = true;
                                break;
                            }
                        }
                    }
                    if (mul)
                    {
                        count += num1 * num2;
                    }
                }
            }


            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }
    }
}

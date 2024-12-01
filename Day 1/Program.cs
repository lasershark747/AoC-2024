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
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            foreach(var c in input)
            {
                left.Add(int.Parse(c.Substring(0, 5)));
                right.Add(int.Parse(c.Substring(8, 5)));
                
            }
            left.Sort();
            right.Sort();
            //Part 1
            
            
            for (int i = 0; i < left.Count; i++) 
            {
                count += Math.Abs(left[i] - right[i]);
            }

            Console.WriteLine("Part 1: " + count);

            count = 0;
            //Part 2
            for (int i = 0; i < left.Count; i++) 
            {
                int count2 = 0;
                for (int j = 0; j < right.Count;j++) 
                {
                    if (left[i] == right[j])
                    {
                        count2++;
                    }
                }
                count += count2 * left[i];
            }


            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }
    }
}

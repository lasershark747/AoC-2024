using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            ulong count = 0;
            string[] input2 = input[0].Split(' ');
            List<ulong> stones = new List<ulong>();

            foreach (string s in input2)
            {
                stones.Add(ulong.Parse(s));
            }

            //Part 1
            Dictionary<(ulong, ulong), ulong> dict = new Dictionary<(ulong, ulong), ulong>();
            foreach (ulong stone in stones)
            {
                count += end(stone, 25, dict);
            }




            Console.WriteLine("Part 1: " + count);

            //Part 2
            count = 0;
            foreach (ulong stone in stones)
            {
                count += end(stone, 75, dict);
            }


            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }

        public static ulong end(ulong stone, ulong blinks, Dictionary<(ulong, ulong), ulong> dict)
        {
            ulong count = 0;
            if (dict.Keys.Contains((stone, blinks)))
            {
                return dict[(stone, blinks)];
            }
            if (blinks == 0)
            {
                return 1;
            }

            if (stone == 0)
            {
                count =  end(1,blinks-1, dict);
            }
            else if (stone.ToString().Length % 2 == 0)
            {
                var temp = stone.ToString();
                count += end(ulong.Parse(temp.Substring(0, temp.Length / 2)),blinks-1,dict);
                count += end(ulong.Parse(temp.Substring(temp.Length / 2)), blinks - 1, dict);
            }
            else
            {
                count = end(stone*2024,blinks-1, dict);
            }

            dict.Add((stone, blinks), count);
            return count;

        }
    }
}

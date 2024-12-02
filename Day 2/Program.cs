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
                string[] level = line.Split(' ');
                List<int> level2 = new List<int>();
                foreach (var num in level)
                {
                    level2.Add(int.Parse(num));
                }
                bool increasing = true;
                if (level2[0] > level2[1])
                {
                    increasing = false;
                }
                bool safe = true;
                for (int i = 0; i < level2.Count-1; i++) 
                {
                    if (Math.Abs(level2[i] - level2[i+1]) > 3 || increase(level2[i], level2[i+1]) != increasing || level2[i] == level2[i+1])
                    {
                        safe = false;
                        break;
                    }
                }
                if (safe)
                {
                    count++;
                }
            }

            Console.WriteLine("Part 1: " + count);
            
            
            //Part 2
            count = 0;
            foreach (string line in input)
            {
                string[] level = line.Split(' ');
                List<int> level2 = new List<int>();

                foreach (var num in level)
                {
                    level2.Add(int.Parse(num));
                }

                bool increasing = true;
                if (level2[0] > level2[1])
                {
                    increasing = false;
                }

                bool safe = true;

                for (int i = 0; i < level2.Count - 1; i++)
                {
                    if (Math.Abs(level2[i] - level2[i + 1]) > 3 || increase(level2[i], level2[i + 1]) != increasing || level2[i] == level2[i + 1])
                    {
                        safe = false;
                        break;
                    }
                }

                if (!safe) 
                {
                    for (int i = 0; i < level2.Count; i++)
                    {
                        safe = true;

                        List<int> dupe = new List<int>();
                        foreach(var c in level2)
                        {
                            dupe.Add(c);
                        }
                        dupe.RemoveAt(i);

                        increasing = true;
                        if (dupe[0] > dupe[1])
                        {
                            increasing = false; 
                        }

                        for (int j = 0; j < dupe.Count - 1; j++)
                        {
                            if (Math.Abs(dupe[j] - dupe[j + 1]) > 3 || increase(dupe[j], dupe[j + 1]) != increasing || dupe[j] == dupe[j + 1])
                            {
                                safe = false;
                                break;
                            }
                        }
                        if (safe)
                        {
                            break;
                        }
                    }
                }

                if (safe)
                {
                    count++;
                }
            }

            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }
        public static bool increase(int first, int second)
        {
            return (first < second);
        }
    }
}

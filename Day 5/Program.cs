using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int count = 0;
            int line = 0;
            Dictionary<string,List<string>> before = new Dictionary<string,List<string>>();
            List<string[]> updates = new List<string[]>();

            for(int i  = 1; i < 100;i++)
            {
                before.Add(i.ToString(), new List<string>());
            }

            while (true)
            {
                if (input[line] == "")
                {
                    line++;
                    break;
                }
                string[] temp = input[line].Split('|');
                before[temp[0]].Add(temp[1]);
                line++;
            }

            for (int i = line; i < input.Length; i++)
            {
                updates.Add(input[i].Split(','));
            }
            List<string[]> incorrect = new List<string[]>();
            //Part 1
            foreach (var v in updates) 
            {
                bool valid = true;
                for (int i = 0; i < v.Length; i++)
                {
                    int j = 0;
                    while (j < i)
                    {
                        if (before[v[i]].Contains(v[j]))
                        {
                            valid = false;
                            break;
                        }
                        j++;
                    }
                }
                if(valid)
                {
                    count += int.Parse(v[(v.Length-1)/2]);
                }
                else
                {
                    incorrect.Add(v);
                }
            }

            Console.WriteLine("Part1: " + count);

            //Part 2
            count = 0;
            foreach(var v in incorrect)
            {
                List<string> temp = new List<string>();
                foreach(var v2 in v)
                {
                    bool insert = true;
                    for(int i = 0;i <temp.Count;i++)
                    {
                        if (before[v2].Contains(temp[i]))
                        {
                            temp.Insert(i, v2);
                            insert = false;
                            break;
                        }
                    }
                    if(insert)
                    {
                        temp.Add(v2);
                    }
                }

                count += int.Parse(temp[(temp.Count - 1) / 2]);
            }

            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }
    }
}

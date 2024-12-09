using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int count = 0;
            int c = 0;


            //Part 1
            List<int> value = new List<int>();
            List<int> stack = new List<int>();
            bool full = true;
            for (int i = 0; i < input[0].Length; i++)
            {
                for (int j = 0; j < int.Parse(input[0][i].ToString()); j++)
                {
                    if (full)
                    {
                        value.Add(1);
                        stack.Add(count);
                        c++;
                    }
                    else
                    {
                        value.Add(-1);
                    }
                }
                if (full)
                {
                    count++;
                }
                full = !full;
            }
            count = 0;


            List<int> values = new List<int>();
            while(stack.Count > 0) 
            {
                if (value[count] == 1)
                {
                    values.Add(stack[0]);
                    stack.RemoveAt(0);
                }
                else if(value[count] == -1)
                {
                    values.Add(stack[stack.Count-1]);
                    stack.RemoveAt(stack.Count-1);
                }
                count++;
            }

            count = 0;
            long t = 0;
            for (int i = 0; i < values.Count; i++)
            {

                t += i * values[i];

            }


            Console.WriteLine("Part 1: " + t);

            //Part 2
            count = 0;
            List<(int,int)> disk = new List<(int,int)>();
            List<int> lens = new List<int>();
            for (int i = 0; i < input[0].Length; i++)
            {
                if (i % 2 == 0)
                {
                    disk.Add((count, int.Parse(input[0][i].ToString())));
                    count++;
                }
                else
                {
                    disk.Add((-1, int.Parse(input[0][i].ToString())));
                }
            }

            for (int i = disk.Count - 1; i >= 0; i--) 
            {
                if (disk[i].Item1 != -1)
                {
                    var v = disk[i];
                    for (int j = 0; j < i; j++)
                    {
                        var v2 = disk[j];
                        if (v2.Item1 == -1)
                        {
                            if (v2.Item2 == v.Item2)
                            {
                                disk[j] = v;
                                disk[i] = v2;
                                break;
                            }
                            else if (v2.Item2 > v.Item2)
                            {
                                int dif = v2.Item2 - v.Item2;
                                disk[j] = v;
                                disk.Insert(j + 1, (-1, dif));
                                disk[i+1] = (-1, v.Item2);
                                i++;
                                break;
                            }

                        }
                    }
                }
            }

            t = 0;
            c = 0;

            for(int i = 0; i < disk.Count; i++)
            {
                if (disk[i].Item1 != -1)
                {
                    for (int j = 0; j < disk[i].Item2; j++)
                    {
                        t += disk[i].Item1 * c;
                        c++;
                    }
                }
                else
                {
                    c += disk[i].Item2;
                }
            }

            Console.WriteLine("Part 2: " + t);
            Console.ReadKey();
        }
    }
}

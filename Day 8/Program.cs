using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            long count = 0;
            Dictionary<char, List<(int, int)>> antenna = new Dictionary<char, List<(int, int)>>();
            for (int i = 0; i < input.Length; i++)
            {
                for(int j =0;  j < input[i].Length; j++)
                {
                    if (input[i][j] != '.')
                    {
                        if (antenna.Keys.Contains(input[i][j]))
                        {
                            antenna[input[i][j]].Add((i, j));
                        }
                        else
                        {
                            List<(int,int)> temp = new List<(int, int)>();
                            temp.Add((i,j));
                            antenna.Add(input[i][j], temp);
                        }
                    }
                }
            }



            //Part 1
            List<(int,int)> intersections = new List<(int,int)> ();
            foreach(var v in antenna.Values)
            {
                for(int i = 0;i< v.Count;i++)
                {
                    for(int j = i+1; j < v.Count; j++)
                    {
                        (int, int) iTOj = (v[i].Item1 - v[j].Item1, v[i].Item2 - v[j].Item2);
                        (int, int) p1 = (v[j].Item1 - iTOj.Item1, v[j].Item2 - iTOj.Item2);
                        (int, int) p2 = (v[i].Item1 + iTOj.Item1, v[i].Item2 + iTOj.Item2);

                        if ((!intersections.Contains(p1)) && inside(p1, input.Length, input[0].Length))
                        {
                            intersections.Add(p1);
                        }
                        if (!(intersections.Contains(p2)) && inside(p2, input.Length, input[0].Length))
                        {
                            intersections.Add(p2);
                        }
                    }
                }
            }




            Console.WriteLine("Part 1: " + intersections.Count);


            //Part 2
            count = 0;
            intersections = new List<(int, int)>();
            foreach (var v in antenna.Values)
            {
                for (int i = 0; i < v.Count; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        (int, int) iTOj = (v[i].Item1 - v[j].Item1, v[i].Item2 - v[j].Item2);
                        (int, int) p1 = (v[j].Item1, v[j].Item2 );
                        (int, int) p2 = (v[i].Item1, v[i].Item2);
                        
                        while (true) 
                        {
                            if (!inside(p1, input.Length, input[0].Length))
                            {
                                break;
                            }
                            if (!intersections.Contains(p1))
                            {
                                intersections.Add(p1);
                            } 
                            p1 = (p1.Item1 - iTOj.Item1, p1.Item2 - iTOj.Item2);
                        }

                        while (true)
                        {
                            if (!inside(p2, input.Length, input[0].Length))
                            {
                                break;
                            }
                            if (!intersections.Contains(p2))
                            {
                                intersections.Add(p2);
                            }
                            p2 = (p2.Item1 + iTOj.Item1, p2.Item2 + iTOj.Item2);
                        }
                    }
                }
            }


            Console.WriteLine("Part 2: " + intersections.Count);
            Console.ReadKey();
        }

        public static bool inside((int,int) p, int i, int j)
        {
            if(p.Item1 < 0 || p.Item2 < 0)
                return false;
            if(p.Item1>=i || p.Item2 >= j)
                return false;

            return true;
        }
    }
}

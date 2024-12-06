using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int count = 0;

            List<List<char>> grid = new List<List<char>>();

            foreach(var v in input)
            {
                List<char> list = new List<char>();
                foreach(var v2 in v)
                {
                    list.Add(v2);
                }
                grid.Add(list);
            }
            (int, int)[] directions = { (-1, 0), (0, 1), (1, 0), (0, -1) };
            (int, int) pos = (-1, -1);
            int direction = 0;
            (int, int) start = (-1, -1);
            (int,int) size = (grid.Count, grid[0].Count);
            for (int i = 0; i < grid.Count; i++)
            {
                for(int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] == '^')
                    {
                        pos = (i,j);
                        start = (i,j);
                        i = 1000000;
                        break;
                    }
                }
            }

            //Part 1
            List<(int,int)> visited = new List<(int,int)> ();

            visited.Add(pos);

            while (true)
            {
                if (outside((pos.Item1 + directions[direction].Item1, pos.Item2 + directions[direction].Item2), size))
                {
                    break;
                }
                if (grid[pos.Item1 + directions[direction].Item1][pos.Item2 + directions[direction].Item2] == '#')
                {
                    direction = (direction + 1) % 4;
                }
                else
                {
                    pos = (pos.Item1 + directions[direction].Item1, pos.Item2 + directions[direction].Item2);
                }
                if(!visited.Contains(pos))
                {
                    visited.Add(pos);
                }
            }



            Console.WriteLine("Part 1: " + visited.Count);

            //Part 2
            List<(int, int, int)> loops = new List<(int, int, int)>();
            for(int i = 0; i < grid.Count; i++)
            {
                Console.WriteLine(i);
                for(int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] == '.')
                    {
                        bool loop = false;
                        List<(int, int, int)> visited2 = new List<(int, int, int)>();
                        (int, int, int) pos2 = (start.Item1, start.Item2, 0);
                        grid[i][j] = '#';
                        while (true)
                        {
                            if (outside((pos2.Item1 + directions[pos2.Item3].Item1, pos2.Item2 + directions[pos2.Item3].Item2), size))
                            {
                                break;
                            }
                            else if (grid[pos2.Item1 + directions[pos2.Item3].Item1][pos2.Item2 + directions[pos2.Item3].Item2] == '#')
                            {
                                pos2.Item3 = (pos2.Item3 + 1)%4;
                            }
                            else
                            {
                                pos2 = (pos2.Item1 + directions[pos2.Item3].Item1, pos2.Item2 + directions[pos2.Item3].Item2, pos2.Item3);
                                if (visited2.Contains(pos2))
                                {
                                    loop = true;
                                    break;
                                }
                                else
                                {
                                    visited2.Add(pos2);
                                }
                            } 
                        }
                        if(loop)
                        {
                            count++;
                        }
                        grid[i][j] = '.';
                    }
                }
            }


            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }

        public static bool outside((int,int) pos, (int,int) size)
        {
            if (pos.Item1 < 0 || pos.Item2 < 0 || pos.Item1 >= size.Item1 || pos.Item2 >= size.Item2)
            {
                return true;
            }
            return false;
        }
    }
}

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
            List<List<char>> grid = new List<List<char>>();
            (int, int)[] directions = { (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };
 
            
            
            //Part 1
            foreach (string line in input)
            {
                List<char> list = new List<char>();
                foreach (char c in line)
                {
                    list.Add(c);
                }
                grid.Add(list);
            }

            for (int i = 0; i < grid.Count; i++)
            {
                for(int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] == 'X')
                    {
                        foreach(var d in directions)
                        {
                            bool valid = true;
                            if(i+3*d.Item1 < 0 || i + 3 * d.Item1 >= grid.Count || j + 3 * d.Item2 < 0 || j + 3 * d.Item2 >= grid[i].Count)
                            {
                                valid = false;
                            }
                            if (valid && grid[i + d.Item1][j + d.Item2] == 'M' && grid[i +2* d.Item1][j +2* d.Item2] == 'A' && grid[i +3* d.Item1][j + 3* d.Item2] == 'S')
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Part 1: " + count);


            //Part 2
            count = 0;

            for (int i = 1; i < grid.Count-1; i++)
            {
                for (int j = 1; j < grid[i].Count-1; j++)
                {
                    if (grid[i][j] == 'A')
                    {
                        if (((grid[i+1][j+1] == 'M' && grid[i-1][j-1] == 'S') || (grid[i + 1][j + 1] == 'S' && grid[i - 1][j - 1] == 'M')) && ((grid[i + 1][j - 1] == 'M' && grid[i - 1][j + 1] == 'S') || (grid[i + 1][j - 1] == 'S' && grid[i - 1][j + 1] == 'M')))
                        {
                            Console.WriteLine((i+1,j+1));
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }
    }
}

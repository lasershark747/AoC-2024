using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_10
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            string[] input = File.ReadAllLines("input.txt");
            List<List<int>> map = new List<List<int>>();
            long count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                map.Add(new List<int>());
                for(int j = 0; j < input[i].Length; j++)
                {
                    map[i].Add(int.Parse(input[i][j].ToString()));  
                }
            }


            //Part 1
            for (int i = 0; i < map.Count; i++)
            {
                for(int j = 0;j < map[i].Count; j++)
                {
                    if (map[i][j] == 0)
                    {
                        count += score(i, j, map);
                    }
                }
            }


            Console.WriteLine("Part 1: " + count);

            //Part 2

            count = 0;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == 0)
                    {
                        count += score2(i, j, map);
                    }
                }
            }


            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }

        public static int score(int y, int x, List<List<int>> grid)
        {
            List<(int,int)> end = new List<(int,int)> ();
            Queue<(int,int)> queue = new Queue<(int, int)> ();
            queue.Enqueue((y, x));
            (int, int)[] directions = { (1, 0), (0, 1), (-1, 0), (0, -1) };
            while (queue.Count > 0) 
            {
                var location = queue.Dequeue();
                if (grid[location.Item1][location.Item2] == 9 && !end.Contains(location))
                {
                    end.Add(location);
                }
                for(int i = 0; i < directions.Length; i++)
                {
                    var next = (location.Item1 + directions[i].Item1, location.Item2 + directions[i].Item2);
                    if(inside(next, grid.Count, grid[0].Count) && grid[location.Item1][location.Item2] - grid[next.Item1][next.Item2] == -1)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            return end.Count;
        }
        public static int score2(int y, int x, List<List<int>> grid)
        {
            List<(int, int)> end = new List<(int, int)>();
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((y, x));
            (int, int)[] directions = { (1, 0), (0, 1), (-1, 0), (0, -1) };
            while (queue.Count > 0)
            {
                var location = queue.Dequeue();
                if (grid[location.Item1][location.Item2] == 9)
                {
                    end.Add(location);
                }
                for (int i = 0; i < directions.Length; i++)
                {
                    var next = (location.Item1 + directions[i].Item1, location.Item2 + directions[i].Item2);
                    if (inside(next, grid.Count, grid[0].Count) && grid[location.Item1][location.Item2] - grid[next.Item1][next.Item2] == -1)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            return end.Count;
        }

        public static bool inside((int, int) p, int i, int j)
        {
            if (p.Item1 < 0 || p.Item2 < 0)
                return false;
            if (p.Item1 >= i || p.Item2 >= j)
                return false;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            long count = 0;
            List<(long,List<long>)> keys = new List<(long,List<long>)>();
            foreach (string line in input)
            {
                string[] a1 = line.Split(':');
                string[] a2 = a1[1].Split(' ');
                List<long> l1 = new List<long>();
                for (int i = 1; i < a2.Length; i++)
                {
                    l1.Add(long.Parse(a2[i]));
                }
                keys.Add((long.Parse(a1[0]), l1));
                
            }

            for(int i = 0; i < keys.Count; i++)
            {
                if (test(keys[i].Item1, 0, keys[i].Item2))
                {
                    count += keys[i].Item1;
                }
            }

            Console.WriteLine("Part 1: " + count);
            //Part 2
            count = 0;
            for (int i = 0; i < keys.Count; i++)
            {
                if (test2(keys[i].Item1, 0, keys[i].Item2))
                {
                    count += keys[i].Item1;
                }
            }


            Console.WriteLine("Part 2: " + count);
            Console.ReadKey();
        }

        public static bool test(long target, long current, List<long> value)
        {
            bool works = false;
            if (value.Count > 0)
            {
                long temp = current * value[0];
                long temp2 = current + value[0];
                List<long> tempList = new List<long>();
                for (int i = 1; i < value.Count; i++)
                {
                    tempList.Add(value[i]);
                }
                works = test(target, temp, tempList);
                if (!works)
                {
                    works = test(target, temp2, tempList);
                }
            }
            else
            {
                works = target == current; 
            }

            return works;
        }
        public static bool test2(long target, long current, List<long> value)
        {
            bool works = false;
            if (value.Count > 0)
            {
                long temp = current * value[0];
                long temp2 = current + value[0];
                long temp3 = long.Parse(current.ToString() + value[0].ToString());

                List<long> tempList = new List<long>();
                for (int i = 1; i < value.Count; i++)
                {
                    tempList.Add(value[i]);
                }
                works = test2(target, temp, tempList);
                if (!works)
                {
                    works = test2(target, temp2, tempList);
                }
                if (!works)
                {
                    works = test2(target, temp3, tempList);
                }
            }
            else
            {
                works = target == current;
            }

            return works;
        }

    }
}

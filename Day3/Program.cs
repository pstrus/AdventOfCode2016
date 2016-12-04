using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {

            PartTwo();



        }

        public static void PartOne()
        {
            var triangles = File.ReadAllLines("Input.txt");


            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);

            int CountOfPossibleTringles = 0;

            foreach (var item in triangles)
            {
                var line = regex.Replace(item, " ").Trim();
                List<int> sides = line.Split(' ').Select(int.Parse).ToList();

                sides.Sort();
                if (sides[0] + sides[1] > sides[2])
                    CountOfPossibleTringles++;

            }
            Console.WriteLine("Possible triangles: " + CountOfPossibleTringles);
            Console.ReadKey();

        }

        public static void PartTwo()
        {
            var triangles = File.ReadAllLines("Input.txt");


            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);

            int CountOfPossibleTringles = 0;

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            foreach (var item in triangles)
            {
                var line = regex.Replace(item, " ").Trim();
                List<int> sides = line.Split(' ').Select(int.Parse).ToList();
                for (int i = 0; i < 3; i++)
                {
                    List<int> list;
                    if (!dict.TryGetValue(i, out list))
                    {
                        list = new List<int>();
                        dict.Add(i, list);
                    }
                    dict[i].Add(sides[i]);

                }

            }

            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < dict[i].Count/3; a++)
                {
                    List<int> list = new List<int>();
                    list.Add(dict[i][3 * a]);
                     list.Add(dict[i][3 * a + 1]);
                     list.Add(dict[i][3 * a + 2]);
                    list.Sort();
                    if (list[0] + list[1] > list[2])
                        CountOfPossibleTringles++;

                }

            }

            Console.WriteLine("Possible triangles: " + CountOfPossibleTringles);
            Console.ReadKey();


        }
    }
}

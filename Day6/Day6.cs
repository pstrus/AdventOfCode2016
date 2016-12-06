using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day6
{
    class Day6
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");

            //set to true for Part Two of the puzzle
            bool PartTwo = true;

            string FinalString = string.Empty ;

            for (int i = 0; i < input[0].Length; i++)
            {
                string lettersInAColumn = new string(input.Select(s => s[i]).ToArray());
                char mostCommonLetter;
                if (PartTwo)
                     mostCommonLetter = lettersInAColumn.GroupBy(s => s).OrderBy(s => s.Count()).First().Key;
                else
                    mostCommonLetter = lettersInAColumn.GroupBy(s => s).OrderByDescending(s => s.Count()).First().Key;

                
                FinalString += mostCommonLetter;
            }


            Console.WriteLine(FinalString);
            Console.ReadKey();
        }
    }
}

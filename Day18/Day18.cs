using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day18
{
    class Day18
    {
        static void Main(string[] args)
        {
            string input = @".^^^.^.^^^.^.......^^.^^^^.^^^^..^^^^^.^.^^^..^^.^.^^..^.^..^^...^.^^.^^^...^^.^.^^^..^^^^.....^....";
            // for part one use 40-1

            int noOfAdditionalRows = 400000 - 1;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string[] rows = new string[noOfAdditionalRows + 1];
            rows[0] = input;

            for (int i = 0; i < noOfAdditionalRows; i++)
            {
                rows[i + 1] = CreateNewRow(rows[i]);
            }

            int dotCount = 0;
            foreach (var row in rows)
            {
                //Console.WriteLine(row);
                foreach (var character in row)
                {
                    if (character == '.') dotCount++;
                }

            }
            sw.Stop();
            Console.WriteLine("safe spot count = " + dotCount + ", time elapsed: =" + sw.Elapsed);
            //46 secs originally, 4.6 without Console.WriteLine
            Console.ReadKey();

        }

        private static string CreateNewRow(string previousRow)
        {
            string result = string.Empty;
            for (int i = 0; i < previousRow.Length; i++)
            {
                if (i == 0) result += GetNextTrapOrSafeSpot('.', previousRow[i], previousRow[i + 1]);
                else if (i < previousRow.Length-1) result += GetNextTrapOrSafeSpot(previousRow[i-1], previousRow[i], previousRow[i + 1]);
                else result += GetNextTrapOrSafeSpot(previousRow[i - 1], previousRow[i], '.');
            }
            return result;
        }

        private static char GetNextTrapOrSafeSpot(char v1, char v2, char v3)
        {
            if (v1 == '^' && v2 == '^' && v3 == '.') return '^';
            else if (v1 == '.' && v2 == '^' && v3 == '^') return '^';
            else if (v1 == '^' && v2 == '.' && v3 == '.') return '^';
            else if (v1 == '.' && v2 == '.' && v3 == '^') return '^';
            else return '.';
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Day24
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");

            char[][] arr = new char[input.Count()][];

            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = input[i].ToCharArray();

            }
            //starting point 5,135
            Console.ReadKey();
        }
    }
}

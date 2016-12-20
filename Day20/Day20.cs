using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Day20
{
    class Day20
    {
        static void Main(string[] args)
        {
            long current = 0;
            List<long> results = new List<long>();

            var input = File.ReadAllLines("Input.txt");
            var lastRow = input.Last();

            while (current <= uint.MaxValue)
            {
                bool increase = true;
                foreach (var line in input)
                {
                    var boundries = line.Trim().Split('-');
                    long lowerBoundry = long.Parse(boundries[0]);
                    long upperBoundry = long.Parse(boundries[1]);
              
                    if (current >= lowerBoundry && current <= upperBoundry) 
                    {
                        current = upperBoundry + 1;
                        increase = false;
                        break;
                    }

                    if (line == lastRow)
                        results.Add(current);
                }
                if(increase) current++;

            }
            Console.WriteLine("First=" + results.First());
            Console.WriteLine("Count=" + results.Count());
            Console.ReadKey();
        }
    } 
}




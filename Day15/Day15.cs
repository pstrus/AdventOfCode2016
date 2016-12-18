using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day15
{
    class Day15
    {
        static void Main(string[] args)
        {
            int requestedSlot = 0;
            int time = 0;
            List<Disc> discList = new List<Disc>();

            bool foundStartingTime = false;

            //for inputTest.txt expected time-1 = 5
            var input = File.ReadAllLines("Input.txt");
            foreach (var line in input)
            {
                var items = line.Split(' ');
                discList.Add(new Disc() { noOfPoisitons = int.Parse(items[3]), startingPosition = int.Parse(items[items.Length - 1].Split('.')[0])});

            }

            while (!foundStartingTime)
            {

                for (int i  = 0; i  < discList.Count; i ++)
                {
                    if ((discList[i].startingPosition + i + time + 1) % discList[i].noOfPoisitons != requestedSlot) break;
                    if (i+1 == discList.Count) foundStartingTime = true;
                }

                time++;
            }

            Console.WriteLine(time - 1);
            Console.ReadKey();

        }
        static void Main2(string[] args)
        {
            var input = new[] { 1, 17, 0, 7, 2, 19, 0, 5, 0, 3, 5, 13, 0, 11 };
            Console.WriteLine(Enumerable.Range(0, int.MaxValue).TakeWhile(time => Enumerable.Range(0, 7).Select(i => (input[2 * i] + time + i + 1) % input[2 * i + 1]).Count(a => a != 0) != 0).Last() + 1);
            Console.ReadKey();
        }
    }

    struct Disc
    {
        public int startingPosition;
        public int noOfPoisitons;
    }




}


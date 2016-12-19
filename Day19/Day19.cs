using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Day19
    {
        static void Main(string[] args)
        {

            int noOfElves = 3014387;
            int[] Elves = new int[noOfElves / 2 +1 ];
            Elves[0] = noOfElves;
            for (int i = 1; i <= noOfElves /2   ; i++) Elves[i] =  2*i -1  ;
            while (Elves.Count() > 1) Elves = RemoveElves(Elves);
            Console.WriteLine(Elves[0]);
            Console.ReadKey();
            
        }

        public static int[] RemoveElves(int[] arr)
        {

            if (arr.Count() % 2 == 0)
            {
                return arr.Where((value, index) => index % 2 == 0).ToArray();
            }
            else
            {
                int[] temptArr = arr.Where((value, index) => index % 2 == 0).ToArray();
                int[] resultArr = new int[temptArr.Length];
                for (int i = 0; i < temptArr.Length; i++)
                {
                    resultArr[(i + 1) % resultArr.Length] = temptArr[i];
                }
                return resultArr;

            }
            
        
        }
    }



}

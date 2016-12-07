using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day7
{
    class Day7
    {
        static void Main(string[] args)
        {
            //count should be 2 with InputTest.txt;
            var input = File.ReadAllLines("Input.txt");
            int count = 0;
            foreach (var item in input)
            {


                string pattern = @"\[(.*?)\]";
                string[] result = Regex.Split(item, pattern);


                if (SupportsAbba(result.Where((value,index) => index % 2 ==0).ToArray()) && !SupportsAbba(result.Where((value, index) => index % 2 != 0).ToArray()))
                    count++;

            }

            Console.WriteLine("IPs with TLS support: " + count);
            Console.ReadKey();
        }

        public static bool SupportsAbba(string[] IPsArray)
        {
            bool result = false;

            foreach (var IP in IPsArray)
            {
                for (int i = 0; i <= IP.Length - 4; i++)
                {
                    if (IP[i] != IP[i + 1] && IP[i + 1] == IP[i + 2] && IP[i] == IP[i + 3])
                        result = true;
                }

            }



            return result;
        }
    }
}

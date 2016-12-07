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
            //count should be 2 with InputTest.txt; and 3 with InputTestAba;
            var input = File.ReadAllLines("Input.txt");
            int countABBA = 0;
            int countABA = 0;
            foreach (var item in input)
            {


                string pattern = @"\[(.*?)\]";
                string[] result = Regex.Split(item, pattern);

                string[] OutsideBracketsBits = result.Where((value, index) => index % 2 == 0).ToArray();
                string[] InsideBracketsBits = result.Where((value, index) => index % 2 != 0).ToArray();

                if (SupportsAbba(OutsideBracketsBits) && !SupportsAbba(InsideBracketsBits))
                    countABBA++;
       
                if (SupportsAba(OutsideBracketsBits, InsideBracketsBits))
                    countABA++;


            }

            Console.WriteLine("IPs with TLS support: " + countABBA);
            Console.WriteLine("IPs with SSL support: " + countABA);

            Console.ReadKey();
        }

        private static bool SupportsAba(string[] outsideBracketsBits, string[] insideBracketsBits)
        {


            foreach (var outBit in outsideBracketsBits)
            {
                for (int i = 0; i <= outBit.Length - 3; i++)
                {
                    if (outBit[i] != outBit[i + 1] && outBit[i] == outBit[i + 2])
                    {
                        char[] c = { outBit[i+1], outBit[i], outBit[i+1] };
                        string searchString = new string(c);
                        if (insideBracketsBits.Any(s => s.Contains(searchString)))
                            return true;
                    }
                }
            }
            return false;
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

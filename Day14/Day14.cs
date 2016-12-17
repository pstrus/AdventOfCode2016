using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Day14
{
    class Day14
    {
        static void Main(string[] args)
        {
            string input = "zpqevtbw";
            int counter = 0;
            int increment = 10000;
            List<string> MD5HashesList = new List<string>();

            List<int> ResultIndicies = new List<int>();

            while (ResultIndicies.Count < 64)
            {
                MD5HashesList = AddMD5Hashes(MD5HashesList, increment, input);
                for (int i = counter; i < counter + increment - 1000; i++)
                {

                    if (Regex.IsMatch(MD5HashesList[i], @"(.)\1\1"))
                    {
                        char char3timesInARow = Regex.Match(MD5HashesList[i], @"(.)\1\1").ToString()[0];

                        bool ElementRepeated5TimesExists = MD5HashesList.Skip(i+1).Take(1000).Any(item => CharRepeated5Times(item, char3timesInARow)); //Regex.IsMatch(item, @"([^" + char3timesInARow + @"])" + @"\1\1\1\1"));


                        if (ElementRepeated5TimesExists) ResultIndicies.Add(i);
                        
                    }


                }
                counter += increment-1000;

            }

            Console.WriteLine("64 index = " + ResultIndicies[63]);
            Console.ReadKey();


        }


        public static string GetMD5Hash(string input)
        {
            
            byte[] encodedPassword = new UTF8Encoding().GetBytes(input);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash)
                .Replace("-", string.Empty)
                .ToLower();
            return encoded;
        }

        public static List<string> AddMD5Hashes(List<string> list,int noOfTimes, string input)
        {
            List<string> newList = list;
            int currentCount = list.Count;
            for (int i = currentCount; i < currentCount+noOfTimes; i++)
            {
                newList.Add(GetMD5Hash(input + i.ToString()));

            }
            return newList;



        }

        public static bool CharRepeated5Times(string input, char c)
        {
            
            for (int i = 0; i < input.Length-5; i++)
            {
                if (input[i] == c && input[i] == input[i + 1] && input[i + 1] == input[i + 2] && input[i + 2] == input[i + 3] && input[i + 3] == input[i + 4])
                    return true;

            }

            return false;
        }
    }
}

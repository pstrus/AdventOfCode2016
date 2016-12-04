using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Day4
{
    class Day4
    {
        static void Main(string[] args)
        {
            
            // InputTest.txt - result exspected 1514
            var input = File.ReadAllLines("Input.txt");

            //string[] input = { @"qzmt-zixmtkozy-ivhz-343[abcde]" };
            //Console.WriteLine("Sum of valid sectorId = " + result);
            Day4.PartTwo(input);
            Console.ReadKey();
            
        }
        static void PartOne(string[] input)
        {
            int result = 0; 
            foreach (var item in input)
            {
                Room room = new Room(item);
                if (room.Validate())
                    result += room.sectorId;
            }
            Console.WriteLine("Sum = " + result);

        }

        static void PartTwo(string[] input)
        {
            foreach (var item in input)
            {
                IDictionary<string, int> resultDict = new Dictionary<string, int>();
                Room room = new Room(item, true);
                KeyValuePair<string, int> kv = room.GetDecipheredCodeAndSector();
                if (kv.Key.Contains("north"))
                    Console.WriteLine("Room = " + kv.Key + " ,sector= " + kv.Value);
                resultDict.Add(kv);


            }

        }
    }



    public class Room
    {
        public string checksum;
        public int sectorId;
        public string letters;
        public string decipheredCode;

        public Room (string entryString)
        {
            checksum = GetChecksum(entryString);
            GetIdAndLetters(entryString);

        }

        public Room (string entryString, bool PartTwo )
            : this(entryString)
        {
            
           decipheredCode = GetDecipheredCode(entryString);

        }

        private string GetDecipheredCode(string entryString)
        {
            string code = entryString.Split('[')[0];
            code = code.Replace('-', ' ');
            string decipheredCode = String.Empty;
            foreach (char item in code)
            {
                if (Char.IsLetter(item))
                {

                        decipheredCode += (char)((Convert.ToUInt16(item) -97 + (sectorId % 26)) % 26 + 97 );
                }
                else
                    decipheredCode += item;  

            }
            return decipheredCode;
        }

        private void GetIdAndLetters(string entryString)
        {
            int index = entryString.IndexOf("[");
            string temp = entryString.Substring(0, index);
            string[] lettersSplit = temp.Split('-');
            for (int i = 0; i < lettersSplit.Count()-1; i++)
            {
                this.letters += lettersSplit[i];
            }
            sectorId = int.Parse(lettersSplit[lettersSplit.Count()-1]);

        }


        private string GetChecksum(string entryString)
        {
            var pattern = @"\[(.*?)\]";
            var matches = Regex.Matches(entryString, pattern);
            string temp = matches[0].ToString();
            return temp.Substring(1, temp.Length - 2);
        }

        public bool Validate()
        {

            var counts = letters.GroupBy(c => c).OrderBy(c => c.Key).ToDictionary(grp => grp.Key, grp => grp.Count()).OrderByDescending(c=>c.Value);
            var FirstFive = counts.Take(5).Select(c => c.Key);

            string temp = string.Empty;

            foreach (var item in FirstFive)
            {
                temp += item;
            }


            return temp == checksum;
        }

        public KeyValuePair<string,int> GetDecipheredCodeAndSector()
        {
            string temp = decipheredCode.Substring(0, decipheredCode.LastIndexOf(' '));
            return new KeyValuePair<string, int>(temp, sectorId);
        }

        
    }
}

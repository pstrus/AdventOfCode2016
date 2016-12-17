using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day16
{
    class Day16
    {
        static void Main(string[] args)
        {
            string input = "00111101111101000";
            int diskLength = 35651584;
            
            while (input.Length <= diskLength)
            {
                input = ProcessInput(input);
            }

            string checksum = input.Substring(0, diskLength);

            do
            {
                checksum = GetChecksum(checksum);

            } while (checksum.Length % 2 == 0);


            Console.WriteLine(checksum);
            Console.ReadKey();
        }


        private static string GetChecksum(string checksum)
        {   
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < checksum.Length; i=i+2)
            {
                if (checksum[i] == checksum[i + 1]) result.Append('1');
                else result.Append('0');
            }
            return result.ToString() ;
        }
            

        private static string ProcessInput(string s)
        {
            string cp = s;
            cp = new string(cp.Reverse().ToArray()).Replace('0', 'x').Replace('1', '0').Replace('x', '1');
            return s + "0" + cp;
        }
        
    }
}

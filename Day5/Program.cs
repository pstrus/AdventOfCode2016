using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {


        static void Main(string[] args)
        {
            // given, a password in a string
            string password = @"reyedfim";
            string FinalPassword = String.Empty;

            var FinalPwdPartTwo = new string[8];
   
            int counter = 0;

            for (int i = 0; i < 100000000; i++)
            {
              
                string pwd = password + i.ToString();
                byte[] encodedPassword = new UTF8Encoding().GetBytes(pwd);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToLower();


                if (encoded.Substring(0, 5) == "00000")
                {
                    int position; 
                    if (int.TryParse(encoded.Substring(5, 1), out position) && position >=0 && position<8)
                    {
                        if (FinalPwdPartTwo[position] == null)
                        {
                            FinalPwdPartTwo[position] = encoded.Substring(6, 1);
                            counter++;
                        }

                    }
                   
                }

                if (counter == 8)
                    break;
            }




            foreach (var item in FinalPwdPartTwo)
            {
                Console.Write(item);
            }
            Console.ReadKey();
        }
    }
}

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
   
            int counter = 0;

            for (int i = 0; i < 10000000; i++)
            {
              
                string pwd = password + i.ToString();
                byte[] encodedPassword = new UTF8Encoding().GetBytes(pwd);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToLower();


                if (encoded.Substring(0, 5) == "00000")
                {
                    FinalPassword += encoded.Substring(5, 1);
                    counter++;
                }

                if (counter == 8)
                    break;
            }




            Console.WriteLine(FinalPassword);
            Console.ReadKey();
        }
    }
}

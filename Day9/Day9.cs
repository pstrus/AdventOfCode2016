using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace Day9
{
    class Day9
    {
        static long GetCount2(char[] chars, long n)
        {
            long count = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                {
                    var marker = new string(chars.Skip(i + 1).TakeWhile(ch => ch != ')').ToArray());
                    var arr = marker.Split('x');
                    int nchars = int.Parse(arr[0]);
                    int skip = i + marker.Length + 2;
                    count += GetCount2(chars.Skip(skip).Take(nchars).ToArray(), int.Parse(arr[1]));
                    i = skip + nchars - 1;
                }
                else
                    count++;
            }
            return count * n;
        }


        static long GetCount(char[] chars)
        {
            long count = 0;
            int i = 0;
            while (i<chars.Count())
            {
                if (chars[i] == '(')
                {
                    var marker = new string(chars.Skip(i + 1).TakeWhile(ch => ch != ')').ToArray());
                    var arr = marker.Split('x');
                    int nchars = int.Parse(arr[0]);
                    int ntimes = int.Parse(arr[1]);
                    int skip = i + marker.Length + 2;
                    count += nchars * ntimes;
                    i = skip + nchars ;
                }
                else
                {
                    i++;
                    count++;
                }
                
            }

            return count;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllText("Input.txt");
            Console.WriteLine(GetCount2(lines.ToCharArray(),1));
            Console.ReadKey();
        }
    }
}

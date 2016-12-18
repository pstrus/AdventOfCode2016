using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    class Day18
    {
        static void Main(string[] args)
        {
            //solution inspired by the one posted by JakDrako in here:   
            Point targetPoint = new Point(3, -3);
            Queue<State> queue = new Queue<State>();

            string input = "awrkjxxr";
            string openChars = "bcdef";
            List<string> possiblePath = new List<string>();
            queue.Enqueue(new State("", new Point(0,0)));

            while (queue.Count >0)
            {
                State currentState = queue.Dequeue();
                if (currentState.position == targetPoint)
                {
                    Console.WriteLine(currentState.path);
                    possiblePath.Add(currentState.path);
                }
                else
                {
                    string hash = GetMD5Hash(input + currentState.path);
                    if (openChars.Contains(hash[0]) && currentState.position.Y < 0) queue.Enqueue(new State(currentState.path + 'U', new Point(currentState.position.X, currentState.position.Y + 1)));
                    if (openChars.Contains(hash[1]) && currentState.position.Y > targetPoint.Y) queue.Enqueue(new State(currentState.path + 'D', new Point(currentState.position.X, currentState.position.Y - 1)));
                    if (openChars.Contains(hash[2]) && currentState.position.X > 0) queue.Enqueue(new State(currentState.path + 'L', new Point(currentState.position.X-1, currentState.position.Y )));
                    if (openChars.Contains(hash[3]) && currentState.position.X < targetPoint.X) queue.Enqueue(new State(currentState.path + 'R', new Point(currentState.position.X + 1 , currentState.position.Y)));
                }            

            }
            Console.WriteLine("Shortest path = " + possiblePath.OrderBy(s => s.Length).First());
            Console.WriteLine("Longest path = " + possiblePath.OrderByDescending(s => s.Length).First());
            Console.WriteLine("Longest path length = " + possiblePath.OrderByDescending(s => s.Length).First().Length);
            Console.ReadKey();
        }



        static string GetMD5Hash(string input)
        {

            byte[] encodedPassword = new UTF8Encoding().GetBytes(input);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash)
                .Replace("-", string.Empty)
                .ToLower();
            return encoded;
        }

    }

    public class State
    {
        public State (string Path, Point point)
        {
            this.path = Path;
            position = point;
        }
        public string path = string.Empty;
        public Point position = new Point(0, 0);
    }

}

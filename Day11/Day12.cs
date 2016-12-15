using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day11
{
    class Day12
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            int counter = 0;
            var Registers = new Dictionary<char, int>();
            long iterationCounter = 0;
                while (counter < input.Count())
                {
                    var commandLine = input[counter].Split();
                    string command = commandLine[0];

                    switch (command)
                    {
                        case "inc":
                            char reg = char.Parse(commandLine[1]);
                            Registers[reg]++;
                            counter++;
                            break;

                        case "dec":
                            reg = char.Parse(commandLine[1]);
                            Registers[reg] = Registers[reg] >= 1 ? Registers[reg] - 1 : 0;
                            counter++;
                            break;

                        case "jnz":
                            int check = 0;
                            if (int.TryParse(commandLine[1].ToString(), out check))
                                counter += check > 0 ? int.Parse(commandLine[2]) : 1;
                            else
                            {
                                reg = char.Parse(commandLine[1]);
                                if (!Registers.ContainsKey(reg))
                                    Registers[reg] = 0;
                                counter = Registers[reg] > 0 ? counter + int.Parse(commandLine[2]) : counter + 1;
                            }
                            break;
                        case "cpy":
                            int valueToPut = 0;
                            if (int.TryParse(commandLine[1].ToString(), out valueToPut))
                                Registers[char.Parse(commandLine[2])] = valueToPut;
                            else
                                Registers[char.Parse(commandLine[2])] = Registers[char.Parse(commandLine[1])];
                            counter++;
                            break;
                        default:
                        throw new ArgumentException("Unkown command");
                            
                    }
                
                iterationCounter++;
                Console.WriteLine(iterationCounter);


                
            }
            Console.WriteLine("Iteration Counter : " + iterationCounter + "    Which register to check?");
            char finalReg = char.Parse(Console.ReadLine());
            Console.WriteLine("value in registry: " + finalReg + " = " + Registers[finalReg]);
            Console.ReadKey();

        }
    }
}

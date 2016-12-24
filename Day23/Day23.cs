using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day23
{
    class Day23
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            int counter = 0;
            var Registers = new Dictionary<char, int>();
            //part1 - a refister initialized to 7, part2- to 12
            Registers['a'] = 12;

            long iterationCounter = 0;
            while (counter < input.Count())
            {
                var commandLine = input[counter].Split();
                string command = commandLine[0];

                try
                {
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
                            {
                                int a = 0;
                                if (int.TryParse(commandLine[2].ToString(), out a))
                                    counter += check > 0 ? a: 1;
                                else
                                    counter += Registers[char.Parse(commandLine[2])]
;                            }
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
                        case "tgl":
                            int instructionToToggle = counter + Registers[char.Parse(commandLine[1])];
                            string instructionToBeToggled = input[instructionToToggle];
                            string newInstruction = Toggle(instructionToBeToggled);
                            input[instructionToToggle] = newInstruction;
                            counter++;
                            break;
                        default:
                            throw new ArgumentException("Unkown command");

                    }
                }
                catch
                {
                    Console.WriteLine("iteration = " + iterationCounter + " skipped!");
                    counter++;
                }

                iterationCounter++;




            }
            Console.WriteLine("Iteration Counter : " + iterationCounter + "    Which register to check?");
            char finalReg = char.Parse(Console.ReadLine());
            Console.WriteLine("value in registry: " + finalReg + " = " + Registers[finalReg]);
            Console.ReadKey();

        }

        private static string Toggle(string instructionToBeToggled)
        {
            var instrucstions = instructionToBeToggled.Split();
            string command = instrucstions[0];
            
            if (instrucstions.Count()==2)
            {
                if (command == "inc") instrucstions[0] = "dec";
                else instrucstions[0] = "inc";
            }
            else if (instrucstions.Count() == 3)
            {
                if (command == "jnz") instrucstions[0] = "cpy";
                else instrucstions[0] = "jnz";

            }
            else throw  new ArgumentException("wrong instructions count");

            return string.Join(" ", instrucstions);
        }
    }
}

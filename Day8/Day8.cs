using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using System.IO;

namespace Day8
{
    class Day8
    {
        static void Main(string[] args)
        {
            const int MATRIX_ROWS = 6;
            const int MATRIX_COLUMNS = 50;

            //TestMethod();
            //
            Day8_PartOne(MATRIX_ROWS, MATRIX_COLUMNS);
            Console.ReadLine();
            


        }

        private static void Day8_PartOne(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            var input = File.ReadAllLines("Input.txt");
            foreach (var line in input)
            {
                var words = line.Split(' ');
                if (words[0] == "rect")
                {
                    var rectParams = words[1].Split('x');
                    matrix = ChangeLeftTopSubMatrix(matrix, int.Parse(rectParams[1]), int.Parse(rectParams[0]), 1);
                    PrintMatrix(matrix);
                }
                else
                {
                    if (words[1] == "column")
                    {
                        matrix = RotateColumnBy(matrix, int.Parse(words[2].Split('=')[1]), int.Parse(words[4]));
                    }
                    else
                    {
                        matrix = RotateRowBy(matrix, int.Parse(words[2].Split('=')[1]), int.Parse(words[4]));
                    }
                    PrintMatrix(matrix);
                }

            }
            int countOfPix = CountSpecificNo(matrix, 1);
            Console.WriteLine("Pixels: " + countOfPix);
            
        }

        private static void TestMethod()
        {
            int[,] matrix = new int[3, 7];
            PrintMatrix(matrix);
            matrix = ChangeLeftTopSubMatrix(matrix, 2, 3, 1);
            PrintMatrix(matrix);
            matrix = RotateColumnBy(matrix, 1, 1);
            PrintMatrix(matrix);
            matrix = RotateRowBy(matrix, 0, 4);
            PrintMatrix(matrix);
            matrix = RotateColumnBy(matrix, 1, 1);
            PrintMatrix(matrix);
            Console.ReadLine();
        }

        public static int[,] ChangeLeftTopSubMatrix(int[,] matrix,int rows, int cols,int value)
        {
            int[,] NewMatrix = matrix;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    NewMatrix[i, j] = value;
                }
            }

            return NewMatrix;

        }

        public static int[,] RotateColumnBy(int[,] matrix, int column, int by)
        {
            int colSize = matrix.GetLength(0);
            int[] newColumn = new int[colSize];

            for (int i = 0; i < colSize ; i++)
            {
                newColumn[(i + by) % colSize] = matrix[i, column];

            }

            for (int i = 0; i < colSize; i++)
            {
                matrix[i, column] = newColumn[i];

            }

            return matrix;


        }

        public static int[,] RotateRowBy(int[,] matrix, int row, int by)
        {
            int rowSize = matrix.GetLength(1);
            int[] newRow = new int[rowSize];

            for (int i = 0; i < rowSize; i++)
            {
                newRow[(i + by) % rowSize] = matrix[row, i];

            }

            for (int i = 0; i < rowSize; i++)
            {
                matrix[row, i] = newRow[i];

            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.WriteLine("=====================================" + Environment.NewLine);
            
        }

        public static int CountSpecificNo(int[,] matrix, int Number)
        {
            int result = 0;

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (matrix[i,j] == Number)
                        result++;
                }
                
            }

            return result;
        }


    }


}

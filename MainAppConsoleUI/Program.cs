using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Implementation;

namespace MainAppConsoleUI
{
    internal class Program
    {
        private static void OutputMatrix(Matrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            for (int i = 1; i <= matrix.M; i++)
            {
                for (int j = 1; j <= matrix.N; j++)
                {
                    Console.Write($"{matrix[i, j], 5} ");
                }
                
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var matrixA = new Matrix(2, 3);

            matrixA[1, 1] = 2;
            matrixA[1, 2] = 1;

            matrixA[2, 1] = -3;
            matrixA[2, 2] = 0;

            matrixA[3, 1] = 4;
            matrixA[3, 2] = -1;

            var matrixB = new Matrix(3, 2);

            matrixB[1, 1] = 5;
            matrixB[1, 2] = -1;
            matrixB[1, 3] = 6;

            matrixB[2, 1] = -3;
            matrixB[2, 2] = 0;
            matrixB[2, 3] = 7;


            //var matrixC = ;
            //var matrixD = ;
            //var matrixE = Operations.Multiply(matrixA, 3);
            //var matrixF = Operations.Multiply(matrixA, matrixB);

            Console.WriteLine($"{nameof(matrixA)}:");
            OutputMatrix(matrixA);

            Console.WriteLine($"{nameof(matrixB)}:");
            OutputMatrix(matrixB);

            Console.WriteLine($"{nameof(matrixA)} + {nameof(matrixA)}:");
            OutputMatrix(Operations.Add(matrixA, matrixA));

            Console.WriteLine($"{nameof(matrixB)} - {nameof(matrixB)}:");
            OutputMatrix(Operations.Subtract(matrixB, matrixB));

            Console.WriteLine($"{nameof(matrixA)} * 3:");
            OutputMatrix(Operations.Multiply(matrixA, 3));

            Console.WriteLine($"{nameof(matrixB)} * 5:");
            OutputMatrix(Operations.Multiply(matrixB, 5));

            Console.WriteLine($"{nameof(matrixA)} * {nameof(matrixB)}:");
            OutputMatrix(Operations.Multiply(matrixA, matrixB));

            Console.ReadKey();
        }
    }
}

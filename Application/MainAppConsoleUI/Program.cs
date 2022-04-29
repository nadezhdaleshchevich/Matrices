using System;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Models;

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
            var matrixA = new Matrix(
                new double[3][]
                {
                    new double[] {1, 2},
                    new double[] {3, 4},
                    new double[] {5, 6}
                });

            Console.WriteLine($"{nameof(matrixA)}:");
            OutputMatrix(matrixA);

            //var matrixA = new Matrix(3, 2);

            //matrixA[1, 1] = 2;
            //matrixA[1, 2] = 1;

            //matrixA[2, 1] = -3;
            //matrixA[2, 2] = 0;

            //matrixA[3, 1] = 4;
            //matrixA[3, 2] = -1;

            //var matrixB = new Matrix(3, 2);

            //matrixB[1, 1] = 1;
            //matrixB[1, 2] = 1;

            //matrixB[2, 1] = -3;
            //matrixB[2, 2] = 0;

            //matrixB[3, 1] = 4;
            //matrixB[3, 2] = -1;

            //Console.WriteLine($"{nameof(matrixA)}:");
            //OutputMatrix(matrixA);
            //Console.WriteLine($"{nameof(matrixB)}:");
            //OutputMatrix(matrixB);

            //Console.WriteLine(matrixA != matrixB);


            //var matrixB = new Matrix(2, 3);

            //matrixB[1, 1] = 5;
            //matrixB[1, 2] = -1;
            //matrixB[1, 3] = 6;

            //matrixB[2, 1] = -3;
            //matrixB[2, 2] = 0;
            //matrixB[2, 3] = 7;


            //Console.WriteLine($"{nameof(matrixA)}:");
            //OutputMatrix(matrixA);

            //Console.WriteLine($"{nameof(matrixB)}:");
            //OutputMatrix(matrixB);

            //Console.WriteLine($"{nameof(matrixA)} + {nameof(matrixA)}:");
            //OutputMatrix(matrixA + matrixA);

            //Console.WriteLine($"{nameof(matrixB)} - {nameof(matrixB)}:");
            //OutputMatrix(matrixB - matrixB);

            //Console.WriteLine($"{nameof(matrixA)} * 3:");
            //OutputMatrix(matrixA * 3);

            //Console.WriteLine($"5 * {nameof(matrixB)}:");
            //OutputMatrix(5 * matrixB);

            //Console.WriteLine($"{nameof(matrixA)} * {nameof(matrixB)}:");
            //OutputMatrix(matrixA * matrixB);

            //Console.WriteLine($"{nameof(matrixA)}^T:");
            //OutputMatrix(matrixA.Transpose());

            //var matrixA = new SquareMatrix(3);

            //matrixA[1, 1] = 1;
            //matrixA[1, 2] = 2;
            //matrixA[1, 3] = 1;

            //matrixA[2, 1] = 3;
            //matrixA[2, 2] = -1;
            //matrixA[2, 3] = -1;

            //matrixA[3, 1] = -2;
            //matrixA[3, 2] = 2;
            //matrixA[3, 3] = 3;

            //OutputMatrix(matrixA);

            //var detA = matrixA.Determinant();
            //Console.WriteLine(detA);

            //var matrixB = new SquareMatrix(4);

            //matrixB[1, 1] = 1;
            //matrixB[1, 2] = -2;
            //matrixB[1, 3] = 0;
            //matrixB[1, 4] = 0;

            //matrixB[2, 1] = 3;
            //matrixB[2, 2] = -1;
            //matrixB[2, 3] = -1;
            //matrixB[2, 4] = 2;

            //matrixB[3, 1] = -2;
            //matrixB[3, 2] = 2;
            //matrixB[3, 3] = 3;
            //matrixB[3, 4] = 1;

            //matrixB[4, 1] = 1;
            //matrixB[4, 2] = 1;
            //matrixB[4, 3] = 2;
            //matrixB[4, 4] = 2;

            //OutputMatrix(matrixB);

            //var detB = matrixB.Determinant();
            //Console.WriteLine(detB);

            //var matrixA = new Matrix(3, 2);

            //matrixA[1, 1] = 2;
            //matrixA[1, 2] = 1;

            //matrixA[2, 1] = -3;
            //matrixA[2, 2] = 0;

            //matrixA[3, 1] = 4;
            //matrixA[3, 2] = -1;

            //OutputMatrix(matrixA);

            //var matrixB = new Matrix(3, 2);

            //matrixB[1, 1] = 2;
            //matrixB[1, 2] = 1;

            //matrixB[2, 1] = -3;
            //matrixB[2, 2] = 0;

            //matrixB[3, 1] = 4;
            //matrixB[3, 2] = -1;

            //OutputMatrix(matrixB);



            Console.ReadKey();
        }

        //public static bool EqualTo(double value1, double value2, double epsilon)
        //{
        //    return Math.Abs(value1 - value2) < epsilon;
        //}
    }
}

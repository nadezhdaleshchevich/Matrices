using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Core.Services;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Extensions
{
    public static class Operation
    {
        public static Matrix Add(Matrix matrixA, Matrix matrixB)
        {
            var addition = Container.GetService<IAddition>();

            return addition.Add(matrixA, matrixB);
        }

        public static Matrix Subtract(Matrix matrixA, Matrix matrixB)
        {
            var subtraction = Container.GetService<ISubtraction>();

            return subtraction.Subtract(matrixA, matrixB);
        }

        public static Matrix Multiply(Matrix matrixA, double number)
        {
            var multiplication = Container.GetService<IMultiplication>();

            return multiplication.Multiply(matrixA, number);
        }

        public static Matrix Multiply(Matrix matrixA, Matrix matrixB)
        {
            var multiplication = Container.GetService<IMultiplication>();

            return multiplication.Multiply(matrixA, matrixB);
        }

        public static Matrix Transpose(this Matrix matrix)
        {
            var transposition = Container.GetService<ITransposition>();

            return transposition.Transpose(matrix);
        }

        public static double Determinant(this SquareMatrix matrix)
        {
            var determinantCalculator = Container.GetService<IDeterminantCalculator>();

            return determinantCalculator.Calculate(matrix);
        }

        public static bool Equals(Matrix matrixA, Matrix matrixB)
        {
            var matrixEqualityComparer = Container.GetService<IEqualityComparer<Matrix>>();

            return matrixEqualityComparer.Equals(matrixA, matrixB);
        }
    }
}

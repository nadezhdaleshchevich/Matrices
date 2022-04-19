using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class Multiplication : IMultiplication
    {
        public Matrix Multiply(Matrix matrixA, double number)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            int m = matrixA.M;
            int n = matrixA.N;
            var matrixB = new Matrix(m, n);

            matrixB.ForEach((i, j) => matrixA[i, j] * number);

            return matrixB;
        }

        public Matrix Multiply(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.N != matrixB.M) throw new ArgumentException($"{nameof(matrixA)}, {nameof(matrixB)}");

            int m = matrixA.M;
            int n = matrixA.N;
            int k = matrixB.N;
            var matrixC = new Matrix(m, k);

            matrixC.ForEach((i, j) =>
            {
                double sum = 0;

                for (int l = 1; l <= n; l++)
                {
                    sum += matrixA[i, l] * matrixB[l, j];
                }

                return sum;
            });

            return matrixC;
        }
    }
}

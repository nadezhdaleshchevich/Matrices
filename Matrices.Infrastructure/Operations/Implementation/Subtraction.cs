using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class Subtraction : ISubtraction
    {
        public Matrix Subtract(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.M != matrixB.M) throw new ArgumentException(nameof(matrixB));
            if (matrixA.N != matrixB.N) throw new ArgumentException(nameof(matrixB));


            int m = matrixA.M;
            int n = matrixB.N;

            var matrixC = new Matrix(m, n);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return matrixC;
        }
    }
}

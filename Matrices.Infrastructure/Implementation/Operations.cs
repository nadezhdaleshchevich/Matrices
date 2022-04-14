using System;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Implementation
{
    public static class Operations
    {
        public static Matrix Add(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.M != matrixB.M) throw new ArgumentException(nameof(matrixB));
            if (matrixA.N != matrixB.N) throw new ArgumentException(nameof(matrixB));


            int m = matrixA.M;
            int n = matrixB.N;

            var matrixC = new Matrix(n, m);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return matrixC;
        }

        public static Matrix Subtract(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.M != matrixB.M) throw new ArgumentException(nameof(matrixB));
            if (matrixA.N != matrixB.N) throw new ArgumentException(nameof(matrixB));


            int m = matrixA.M;
            int n = matrixB.N;

            var matrixC = new Matrix(n, m);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return matrixC;
        }

        public static Matrix Multiply(Matrix matrixA, double number)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            int m = matrixA.M;
            int n = matrixA.N;

            var matrixB = new Matrix(n, m);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    matrixB[i, j] = matrixA[i, j] * number;
                }
            }

            return matrixB;
        }

        public static Matrix Multiply(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.N != matrixB.M) throw new ArgumentException($"{nameof(matrixA)}, {nameof(matrixB)}");

            int m = matrixA.M;
            int n = matrixA.N;
            int k = matrixB.N;

            var matrixC = new Matrix(m, k);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    for (int l = 1; l <= n; l++)
                    {
                        matrixC[i, j] += matrixA[i, l] * matrixB[l, j];
                    }
                }
            }

            return matrixC;
        }
    }
}

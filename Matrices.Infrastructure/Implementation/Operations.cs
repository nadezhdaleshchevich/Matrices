using System;
using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Implementation
{
    public static class Operations
    {
        public static Matrix Transpose(this Matrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            int m = matrixA.N;
            int n = matrixA.M;

            var matrixB = new Matrix(m, n);

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    matrixB[i, j] = matrixA[j, i];
                }
            }

            return matrixB;
        }

        public static double Determinant(SquareMatrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            switch (matrixA.N)
            {
                case 1: return matrixA[1, 1];
                case 2: return Determinant2(matrixA);
                case 3: return Determinant3Cramer(matrixA);
            }

            double result = 0;

            for (int i = 1, j = 1; j <= matrixA.M; j++)
            {
                var algebraicAddition = CreateAlgebraicAddition(matrixA, i, j);
                var det = Determinant(algebraicAddition);

                result += (j % 2 == 1 ? matrixA[i, j] : -matrixA[i, j]) * det;
            }

            return result;
        }

        private static double Determinant2(SquareMatrix matrixA)
        {
            if (matrixA.N != 2) throw new ArgumentException(nameof(matrixA));

            return matrixA[1, 1] * matrixA[2, 2] - matrixA[1, 2] * matrixA[2, 1];
        }

        private static double Determinant3Cramer(SquareMatrix matrixA)
        {
            if (matrixA.N != 3) throw new ArgumentException(nameof(matrixA));

            var a = matrixA[1, 1] * matrixA[2, 2] * matrixA[3, 3] 
                    + matrixA[1, 2] * matrixA[2, 3] * matrixA[3, 1]
                    + matrixA[1, 3] * matrixA[2, 1] * matrixA[3, 2];

            var b = matrixA[1, 3] * matrixA[2, 2] * matrixA[3, 1]
                    + matrixA[1, 2] * matrixA[2, 1] * matrixA[3, 3]
                    + matrixA[1, 1] * matrixA[2, 3] * matrixA[3, 2];

            return a - b;
        }

        private static SquareMatrix CreateAlgebraicAddition(SquareMatrix matrixA, int row, int column)
        {
            SquareMatrix matrixB = new SquareMatrix(matrixA.N - 1);

            for (int i = 1; i <= matrixB.M; i++)
            {
                for (int j = 1; j <= matrixB.N; j++)
                {
                    matrixB[i, j] = matrixA[i < row ? i : i + 1, j < column ? j : j + 1];
                }
            }

            return matrixB;
        }
    }
}

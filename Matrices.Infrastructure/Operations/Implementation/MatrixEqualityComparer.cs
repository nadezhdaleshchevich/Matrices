using System;
using System.Collections.Generic;
using System.Linq;
using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class MatrixEqualityComparer : IEqualityComparer<Matrix>
    {
        private const double Epsilon = 0.000001;

        public bool Equals(Matrix matrixA, Matrix matrixB)
        {
            if (ReferenceEquals(matrixA, matrixB))
            {
                return true;
            }

            if (ReferenceEquals(matrixA, null))
            {
                return false;
            }

            if (ReferenceEquals(matrixB, null))
            {
                return false;
            }

            if (matrixA.GetType() != matrixB.GetType())
            {
                return false;
            }

            if (matrixA.M != matrixB.M || matrixA.N != matrixB.N)
            {
                return false;
            }

            int m = matrixA.M;
            int n = matrixA.N;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (Math.Abs(matrixA[i, j] - matrixB[i, j]) > Epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int GetHashCode(Matrix matrix)
        {
            return matrix.GetHashCode();
        }
    }
}

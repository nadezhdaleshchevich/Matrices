using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class MatrixComparer : IMatrixComparer
    {
        private const double Epsilon = 0.001;

        public bool IsEqual(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (ReferenceEquals(matrixA, matrixB))
            {
                return true;
            }
            else if (matrixA.M != matrixB.M || matrixA.N != matrixB.N)
            {
                return false;
            }
            else
            {
                for (int i = 1; i <= matrixA.M; i++)
                {
                    for (int j = 1; j <= matrixA.N; j++)
                    {
                        if (Math.Abs(matrixA[i, j] - matrixB[i, j]) > Epsilon)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}

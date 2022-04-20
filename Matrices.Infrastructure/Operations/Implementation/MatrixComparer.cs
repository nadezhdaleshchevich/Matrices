using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class MatrixComparer : IMatrixComparer
    {
        private const double Epsilon = 0.001;

        public bool Equals(Matrix matrixA, Matrix matrixB)
        {
            if (ReferenceEquals(matrixA, null) && ReferenceEquals(matrixB, null))
                throw new ArgumentNullException($"{nameof(matrixA)}, {nameof(matrixB)}");

            if (ReferenceEquals(matrixA, matrixB))
            {
                return true;
            }
            else if (!ReferenceEquals(matrixA, null) && ReferenceEquals(matrixB, null)
                     || ReferenceEquals(matrixA, null) && !ReferenceEquals(matrixB, null))
            {
                return false;
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

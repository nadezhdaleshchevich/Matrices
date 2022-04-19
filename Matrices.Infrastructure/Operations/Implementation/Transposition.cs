using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class Transposition : ITransposition
    {
        public Matrix Transpose(Matrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            int m = matrixA.N;
            int n = matrixA.M;
            var matrixB = new Matrix(m, n);

            matrixB.ForEach((i, j) => matrixA[j, i]);

            return matrixB;
        }
    }
}

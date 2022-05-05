using System;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class Subtraction : ISubtraction
    {
        private readonly IMatrixFactory _matrixFactory;

        public Subtraction(IMatrixFactory matrixFactory)
        {
            _matrixFactory = matrixFactory ?? throw new ArgumentNullException(nameof(matrixFactory));
        }

        public Matrix Subtract(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixB == null) throw new ArgumentNullException(nameof(matrixB));

            if (matrixA.M != matrixB.M) throw new ArgumentException(nameof(matrixB));
            if (matrixA.N != matrixB.N) throw new ArgumentException(nameof(matrixB));

            int m = matrixA.M;
            int n = matrixA.N;

            var matrixC = _matrixFactory.CreateMatrix(m, n);

            matrixC.ForEach((i, j) => matrixA[i, j] - matrixB[i, j]);

            return matrixC;
        }
    }
}

using System;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class Transposition : ITransposition
    {
        private readonly IMatrixFactory _matrixFactory;

        public Transposition(IMatrixFactory matrixFactory)
        {
            _matrixFactory = matrixFactory ?? throw new ArgumentNullException(nameof(matrixFactory));
        }

        public Matrix Transpose(Matrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            int m = matrixA.N;
            int n = matrixA.M;
            var matrixB = _matrixFactory.CreateMatrix(m, n);

            matrixB.ForEach((i, j) => matrixA[j, i]);

            return matrixB;
        }
    }
}

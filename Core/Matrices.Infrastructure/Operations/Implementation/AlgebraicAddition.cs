using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class AlgebraicAddition : IAlgebraicAddition
    {
        public SquareMatrix Create(SquareMatrix matrixA, int row, int column)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixA.N < 3) throw new ArgumentException(nameof(matrixA.N));
            if (row < 1 || row > matrixA.M) throw new ArgumentOutOfRangeException(nameof(row));
            if (column < 1 || column > matrixA.N) throw new ArgumentOutOfRangeException(nameof(column));

            int n = matrixA.N - 1;
            var algebraicAddition = new SquareMatrix(n);

            algebraicAddition.ForEach((i, j) => matrixA[i < row ? i : i + 1, j < column ? j : j + 1]);

            return algebraicAddition;
        }
    }
}

using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class DeterminantFor2X2Calculator : IDeterminantFor2X2Calculator
    {
        public double Calculate(SquareMatrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixA.N != 2) throw new ArgumentException(nameof(matrixA.N));

            return matrixA[1, 1] * matrixA[2, 2] - matrixA[1, 2] * matrixA[2, 1];
        }
    }
}

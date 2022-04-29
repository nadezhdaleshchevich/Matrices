using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class DeterminantFor1X1Calculator : IDeterminantFor1X1Calculator
    {
        public double Calculate(SquareMatrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixA.N != 1) throw new ArgumentException(nameof(matrixA.N));

            return matrixA[1, 1];
        }
    }
}

using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class DeterminantFor3X3Calculator : IDeterminantFor3X3Calculator
    {
        public double Calculate(SquareMatrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));
            if (matrixA.N != 3) throw new ArgumentException(nameof(matrixA.N));

            var mainDiagonal = CalculateSumMainDiagonal(matrixA);
            var lateralDiagonal = CalculateSumLateralDiagonal(matrixA);

            return mainDiagonal - lateralDiagonal;
        }

        private double CalculateSumMainDiagonal(SquareMatrix matrixA)
        {
            return matrixA[1, 1] * matrixA[2, 2] * matrixA[3, 3]
                   + matrixA[1, 2] * matrixA[2, 3] * matrixA[3, 1]
                   + matrixA[1, 3] * matrixA[2, 1] * matrixA[3, 2];
        }

        private double CalculateSumLateralDiagonal(SquareMatrix matrixA)
        {
            return matrixA[1, 3] * matrixA[2, 2] * matrixA[3, 1]
                   + matrixA[1, 2] * matrixA[2, 1] * matrixA[3, 3]
                   + matrixA[1, 1] * matrixA[2, 3] * matrixA[3, 2];
        }
    }
}

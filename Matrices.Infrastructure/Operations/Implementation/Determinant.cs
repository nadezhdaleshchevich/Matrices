using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class Determinant : IDeterminant
    {
        private readonly IAlgebraicAddition _algebraicAddition;

        public Determinant(IAlgebraicAddition algebraicAddition)
        {
            _algebraicAddition = algebraicAddition ?? throw new ArgumentNullException(nameof(algebraicAddition));
        }

        public double Calculate(SquareMatrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            switch (matrixA.N)
            {
                case 1: return matrixA[1, 1];
                case 2: return CalculateDeterminantFor2x2Matrix(matrixA);
                case 3: return CalculateDeterminantByTriangleRule(matrixA);
            }

            return CalculateDeterminant(matrixA);
        }

        private double CalculateDeterminantFor2x2Matrix(SquareMatrix matrixA)
        {
            return matrixA[1, 1] * matrixA[2, 2] - matrixA[1, 2] * matrixA[2, 1];
        }

        private double CalculateDeterminantByTriangleRule(SquareMatrix matrixA)
        {
            var mainDiagonal = matrixA[1, 1] * matrixA[2, 2] * matrixA[3, 3]
                               + matrixA[1, 2] * matrixA[2, 3] * matrixA[3, 1]
                               + matrixA[1, 3] * matrixA[2, 1] * matrixA[3, 2];

            var lateralDiagonal = matrixA[1, 3] * matrixA[2, 2] * matrixA[3, 1]
                                   + matrixA[1, 2] * matrixA[2, 1] * matrixA[3, 3]
                                   + matrixA[1, 1] * matrixA[2, 3] * matrixA[3, 2];

            return mainDiagonal - lateralDiagonal;
        }
        private double CalculateDeterminant(SquareMatrix matrixA)
        {
            double det = 0;

            for (int i = 1, j = 1; j <= matrixA.M; j++)
            {
                var algebraicAddition = _algebraicAddition.Create(matrixA, i, j);

                det += Sing(j) * matrixA[i, j] * Calculate(algebraicAddition);
            }

            return det;
        }

        private int Sing(int number)
        {
            return number % 2 == 1 ? 1 : -1;
        }
    }
}

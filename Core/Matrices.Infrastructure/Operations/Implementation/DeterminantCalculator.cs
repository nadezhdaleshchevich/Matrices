using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Implementation
{
    internal class DeterminantCalculator : IDeterminantCalculator
    {
        private readonly IDeterminantFor1X1Calculator _determinantFor1X1;
        private readonly IDeterminantFor2X2Calculator _determinantFor2X2;
        private readonly IDeterminantFor3X3Calculator _determinantFor3X3;
        private readonly IAlgebraicAddition _algebraicAddition;

        public DeterminantCalculator(
            IDeterminantFor1X1Calculator determinantFor1X1,
            IDeterminantFor2X2Calculator determinantFor2X2,
            IDeterminantFor3X3Calculator determinantFor3X3,
            IAlgebraicAddition algebraicAddition)
        {
            _determinantFor1X1 = determinantFor1X1 ?? throw new ArgumentNullException(nameof(determinantFor1X1));
            _determinantFor2X2 = determinantFor2X2 ?? throw new ArgumentNullException(nameof(determinantFor2X2));
            _determinantFor3X3 = determinantFor3X3 ?? throw new ArgumentNullException(nameof(determinantFor3X3));
            _algebraicAddition = algebraicAddition ?? throw new ArgumentNullException(nameof(algebraicAddition));
        }

        public double Calculate(SquareMatrix matrixA)
        {
            if (matrixA == null) throw new ArgumentNullException(nameof(matrixA));

            switch (matrixA.N)
            {
                case 1: return _determinantFor1X1.Calculate(matrixA);
                case 2: return _determinantFor2X2.Calculate(matrixA);
                case 3: return _determinantFor3X3.Calculate(matrixA);
            }

            return CalculateRecursion(matrixA);
        }

        public double CalculateRecursion(SquareMatrix matrixA)
        {
            if (matrixA.N == 3)
            {
                return _determinantFor3X3.Calculate(matrixA);
            }

            double det = 0;

            for (int i = 1, j = 1; j <= matrixA.N; j++)
            {
                var algebraicAddition = _algebraicAddition.Create(matrixA, i, j);

                det += Sing(j) * matrixA[i, j] * CalculateRecursion(algebraicAddition);
            }

            return det;
        }

        private int Sing(int number)
        {
            return number % 2 == 1 ? 1 : -1;
        }
    }
}

using System.Collections.Generic;
using Autofac;
using Matrices.Infrastructure.Implementation;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Extensions
{
    public static class Operation
    {
        private static readonly IDeterminantCalculator DeterminantCalculator = Container.Instance.Resolve<IDeterminantCalculator>();
        private static readonly IEqualityComparer<Matrix> matrixEqualityComparer = Container.Instance.Resolve<IEqualityComparer<Matrix>>();
        private static readonly ITransposition Transposition = Container.Instance.Resolve<ITransposition>();

        public static bool Equals(Matrix matrixA, Matrix matrixB)
        {
            return matrixEqualityComparer.Equals(matrixA, matrixB);
        }

        public static Matrix Transpose(this Matrix matrix)
        {
            return Transposition.Transpose(matrix);
        }

        public static double Determinant(this SquareMatrix matrix)
        {
            return DeterminantCalculator.Calculate(matrix);
        }
    }
}

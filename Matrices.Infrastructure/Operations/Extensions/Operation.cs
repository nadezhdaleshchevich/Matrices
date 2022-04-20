using Autofac;
using Matrices.Infrastructure.Implementation;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Extensions
{
    public static class Operation
    {
        private static readonly IAddition Addition = Container.Instance.Resolve<IAddition>();
        private static readonly IDeterminant Determinant = Container.Instance.Resolve<IDeterminant>();
        private static readonly IMatrixComparer MatrixComparer = Container.Instance.Resolve<IMatrixComparer>();
        private static readonly ISubtraction Subtraction = Container.Instance.Resolve<ISubtraction>();
        private static readonly IMultiplication Multiplication = Container.Instance.Resolve<IMultiplication>();
        private static readonly ITransposition Transposition = Container.Instance.Resolve<ITransposition>();

        public static Matrix Add(Matrix matrixA, Matrix matrixB)
        {
            return Addition.Add(matrixA, matrixB);
        }

        public static Matrix Subtract(Matrix matrixA, Matrix matrixB)
        {
            return Subtraction.Subtract(matrixA, matrixB);
        }

        public static Matrix Multiply(Matrix matrixA, double number)
        {
            return Multiplication.Multiply(matrixA, number);
        }

        public static Matrix Multiply(Matrix matrixA, Matrix matrixB)
        {
            return Multiplication.Multiply(matrixA, matrixB);
        }

        public static bool Equals(Matrix matrixA, Matrix matrixB)
        {
            return MatrixComparer.Equals(matrixA, matrixB);
        }

        public static Matrix Transpose(this Matrix matrix)
        {
            return Transposition.Transpose(matrix);
        }

        public static double CalculateDeterminant(this SquareMatrix matrix)
        {
            return Determinant.Calculate(matrix);
        }
    }
}

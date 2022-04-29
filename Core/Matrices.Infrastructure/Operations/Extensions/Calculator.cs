using Autofac;
using Matrices.Infrastructure.Implementation;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;


namespace Matrices.Infrastructure.Operations.Extensions
{
    public static class Calculator
    {
        private static readonly IAddition Addition = Container.Instance.Resolve<IAddition>();
        private static readonly ISubtraction Subtraction = Container.Instance.Resolve<ISubtraction>();
        private static readonly IMultiplication Multiplication = Container.Instance.Resolve<IMultiplication>();

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
    }
}

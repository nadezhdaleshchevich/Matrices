using Autofac;
using Matrices.Infrastructure.Implementation;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Extensions
{
    public static class Operations
    {
        private static readonly ITransposition Transposition = Container.Instance.Resolve<ITransposition>();
        private static readonly IDeterminant Determinant = Container.Instance.Resolve<IDeterminant>();

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

using Autofac;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Extensions
{
    public static class Operations
    {
        private static readonly ITransposition Transposition;

        static Operations()
        {
            Transposition = Container.Instance.Resolve<ITransposition>();
        }
        public static Matrix Transpose(this Matrix matrixA)
        {
            return Transposition.Transpose(matrixA);
        }
    }
}

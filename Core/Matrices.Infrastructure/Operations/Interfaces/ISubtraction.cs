using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface ISubtraction
    {
        Matrix Subtract(Matrix matrixA, Matrix matrixB);
    }
}

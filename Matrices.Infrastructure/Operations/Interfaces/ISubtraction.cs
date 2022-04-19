using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface ISubtraction
    {
        Matrix Subtract(Matrix matrixA, Matrix matrixB);
    }
}

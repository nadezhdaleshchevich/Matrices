using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IMatrixComparer
    {
        bool IsEqual(Matrix matrixA, Matrix matrixB);
    }
}

using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IMatrixComparer
    {
        bool Equals(Matrix matrixA, Matrix matrixB);
    }
}

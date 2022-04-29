using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IAddition
    {
        Matrix Add(Matrix matrixA, Matrix matrixB);
    }
}

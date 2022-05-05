using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IAddition
    {
        Matrix Add(Matrix matrixA, Matrix matrixB);
    }
}

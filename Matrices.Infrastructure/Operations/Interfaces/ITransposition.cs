using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface ITransposition
    {
        Matrix Transpose(Matrix matrixA);
    }
}

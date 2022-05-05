using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface ITransposition
    {
        Matrix Transpose(Matrix matrixA);
    }
}

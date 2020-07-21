using Matrices.Infrastructure.Core.Models;

namespace Matrices.Operations.Interfaces
{
    internal interface IMatrixAdditionSubtractionService
    {
        Matrix Add(Matrix first, Matrix second);
        Matrix Subtract(Matrix first, Matrix second);
    }
}

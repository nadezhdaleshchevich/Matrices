using Matrices.Infrastructure.Core.Models;

namespace Matrices.Operations.Interfaces
{
    internal interface IMatrixMultiplicationService
    {
        Matrix Multiply(Matrix matrix, double number);
        Matrix Multiply(Matrix first, Matrix second);
    }
}

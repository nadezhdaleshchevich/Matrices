using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IMultiplication
    {
        Matrix Multiply(Matrix matrixA, double number);
        Matrix Multiply(Matrix matrixA, Matrix matrixB);
    }
}

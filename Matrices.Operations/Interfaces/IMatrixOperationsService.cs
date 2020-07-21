using Matrices.Infrastructure.Core.Models;

namespace Matrices.Operations.Interfaces
{
    public interface IMatrixOperationsService
    {
        Matrix Add(Matrix first, Matrix second);
        Matrix Subtract(Matrix first, Matrix second);
        Matrix Multiply(Matrix matrix, double number);
        Matrix Multiply(Matrix first, Matrix second);
    }
}

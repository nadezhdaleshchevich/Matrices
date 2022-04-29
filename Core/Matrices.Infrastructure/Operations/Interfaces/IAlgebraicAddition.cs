using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IAlgebraicAddition
    {
        SquareMatrix Create(SquareMatrix matrixA, int row, int column);
    }
}

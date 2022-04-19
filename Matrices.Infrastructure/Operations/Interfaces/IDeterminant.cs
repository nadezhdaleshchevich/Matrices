using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IDeterminant
    {
        double Calculate(SquareMatrix matrixA);
    }
}

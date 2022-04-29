using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IDeterminantCalculator
    {
        double Calculate(SquareMatrix matrixA);
    }
}

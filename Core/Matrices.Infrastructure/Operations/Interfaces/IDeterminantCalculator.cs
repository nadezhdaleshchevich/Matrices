using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Operations.Interfaces
{
    internal interface IDeterminantCalculator
    {
        double Calculate(SquareMatrix matrixA);
    }
}

using Matrices.Infrastructure.Core.Models;
using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Interfaces;

namespace Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Implementations
{
    internal class MatrixSizeValidationService : IMatrixSizeValidationService
    {
        public (bool IsValid, string ValidationMessage) IsMatrixSizeValid(Matrix first, Matrix second)
        {
            if (first.M != second.M)
            {
                return (false, "Numbers of rows must be equal");
            }

            if (first.N != second.N)
            {
                return (false, "Numbers of columns must be equal");
            }

            return (true, null);
        }
    }
}
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Interfaces
{
    internal interface IMatrixSizeValidationService
    {
        (bool IsValid, string ValidationMessage) IsMatrixSizeValid(Matrix first, Matrix second);
    }
}

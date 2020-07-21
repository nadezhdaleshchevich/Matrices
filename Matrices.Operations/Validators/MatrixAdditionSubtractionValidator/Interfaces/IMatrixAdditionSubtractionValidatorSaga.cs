using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Implementations;

namespace Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Interfaces
{
    internal interface IMatrixAdditionSubtractionValidatorSaga
    {
        (bool IsValid, string ValidationMessage) IsMatricesValid(MatrixAdditionSubtractionValidatorSagaContext context);
    }
}

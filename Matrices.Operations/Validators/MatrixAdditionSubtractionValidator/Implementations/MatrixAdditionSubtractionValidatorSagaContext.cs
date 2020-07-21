using Matrices.Infrastructure.Core.Models;

namespace Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Implementations
{
    internal class MatrixAdditionSubtractionValidatorSagaContext
    {
        public MatrixAdditionSubtractionValidatorSagaContext(Matrix first, Matrix second)
        {
            First = first;
            Second = second;
        }

        public Matrix First { get; }
        public Matrix Second { get; }
    }
}

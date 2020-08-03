using System;
using Matrices.Infrastructure.ChainOfHandlers.Interfaces;
using MatrixValidationContext = Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models.MatrixAdditionSubtractionValidationContext;
using MatrixValidationResult = Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models.MatrixAdditionSubtractionValidationResult;

namespace Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Handlers
{
    internal class MatrixSizeEqualHandler : IChainHandler<MatrixValidationContext, MatrixValidationResult>
    {
        public bool Handle(MatrixValidationContext context, MatrixValidationResult result)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (result == null) throw new ArgumentNullException(nameof(result));

            if (context.First.M != context.Second.M)
            {
                result.IsValid = false;
                result.Error = "Numbers of rows must be equal";
            }

            if (context.First.N != context.Second.N)
            {
                result.IsValid = false;
                result.Error = "Numbers of columns must be equal";
            }

            return result.IsValid;
        }
    }
}

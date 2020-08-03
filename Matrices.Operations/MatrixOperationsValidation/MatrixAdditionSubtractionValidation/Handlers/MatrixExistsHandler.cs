using System;
using Matrices.Infrastructure.ChainOfHandlers.Interfaces;
using MatrixValidationContext = Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models.MatrixAdditionSubtractionValidationContext;
using MatrixValidationResult = Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models.MatrixAdditionSubtractionValidationResult;

namespace Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Handlers
{
    internal class MatrixExistsHandler : IChainHandler<MatrixValidationContext, MatrixValidationResult>
    {
        public bool Handle(MatrixValidationContext context, MatrixValidationResult result)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (result == null) throw new ArgumentNullException(nameof(result));

            result.IsValid = true;

            if (context.First == null)
            {
                result.IsValid = false;
                result.Error = $"The {nameof(context.First)} matrix can not be null";
            }

            if (context.Second == null)
            {
                result.IsValid = false;
                result.Error = $"The {nameof(context.Second)} matrix can not be null";
            }

            return result.IsValid;
        }
    }
}

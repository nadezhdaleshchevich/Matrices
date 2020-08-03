using System;
using System.Collections.Generic;
using Matrices.Infrastructure.ChainOfHandlers.Extensions;
using Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Handlers;
using Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Operations.MatrixOperationsValidation.Extensions
{
    public static class MatrixOperationsValidationExtensions
    {
        public static void AddMatrixOperationsValidation(this IServiceCollection services)
        {
            services.AddChainOfHandlers<MatrixAdditionSubtractionValidationContext, MatrixAdditionSubtractionValidationResult>(
                new List<Type>
                {
                    typeof(MatrixExistsHandler),
                    typeof(MatrixSizeEqualHandler)
                });
        }
    }
}

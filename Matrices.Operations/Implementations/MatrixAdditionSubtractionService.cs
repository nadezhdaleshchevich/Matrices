using System;
using Matrices.Infrastructure.ChainOfHandlers.Interfaces;
using Matrices.Infrastructure.Core.Models;
using Matrices.Operations.Interfaces;
using MatrixValidationContext = Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models.MatrixAdditionSubtractionValidationContext;
using MatrixValidationResult = Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models.MatrixAdditionSubtractionValidationResult;

namespace Matrices.Operations.Implementations
{
    internal class MatrixAdditionSubtractionService : IMatrixAdditionSubtractionService
    {
        private readonly IChainService<MatrixValidationContext, MatrixValidationResult> _validationChainService;

        public MatrixAdditionSubtractionService(IChainService<MatrixValidationContext, MatrixValidationResult> validationChainService)
        {
            _validationChainService = validationChainService;
        }

        public Matrix Add(
            Matrix first, 
            Matrix second)
        {
            var result = IsValid(first, second);

            if (!result.IsValid)
            {
                throw new ArgumentException(result.Error);
            }

            return Calculate(first, second, (a, b) => a + b);
        }

        public Matrix Subtract(
            Matrix first, 
            Matrix second)
        {
            var result = IsValid(first, second);

            if (!result.IsValid)
            {
                throw new ArgumentException(result.Error);
            }

            return Calculate(first, second, (a, b) => a - b);
        }

        private (bool IsValid, string Error) IsValid(
            Matrix first, 
            Matrix second)
        {
            var context = new MatrixValidationContext
            {
                First = first,
                Second = second
            };

            var result = new MatrixValidationResult();

            _validationChainService.Run(context, result);

            return (result.IsValid, result.Error);
        }

        private static Matrix Calculate(
            Matrix first, 
            Matrix second, 
            Func<double, double, double> calculator)
        {
            var numberOfRows = first.M;
            var numberOfColumns = first.M;
            var result = new Matrix(numberOfRows, numberOfColumns);

            for (var i = 1; i <= numberOfRows; i++)
            {
                for (var j = 1; j <= numberOfColumns; j++)
                {
                    result[i, j] = calculator(first[i, j], second[i, j]);
                }
            }

            return result;
        }
    }
}
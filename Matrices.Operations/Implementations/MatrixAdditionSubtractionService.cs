using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Operations.Interfaces;
using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Implementations;
using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Interfaces;

namespace Matrices.Operations.Implementations
{
    internal class MatrixAdditionSubtractionService : IMatrixAdditionSubtractionService
    {
        private readonly IMatrixAdditionSubtractionValidatorSaga _validatorSaga;

        public MatrixAdditionSubtractionService(IMatrixAdditionSubtractionValidatorSaga validatorSaga)
        {
            _validatorSaga = validatorSaga;
        }

        public Matrix Add(Matrix first, Matrix second)
        {
            var context = new MatrixAdditionSubtractionValidatorSagaContext(first, second);
            var result = _validatorSaga.IsMatricesValid(context);

            if (!result.IsValid)
                throw new ArgumentException(result.ValidationMessage);

            return Calculate(first, second, (a, b) => a + b);
        }

        public Matrix Subtract(Matrix first, Matrix second)
        {
            var context = new MatrixAdditionSubtractionValidatorSagaContext(first, second);
            var result = _validatorSaga.IsMatricesValid(context);

            if (!result.IsValid)
                throw new ArgumentException(result.ValidationMessage);

            return Calculate(first, second, (a, b) => a - b);
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
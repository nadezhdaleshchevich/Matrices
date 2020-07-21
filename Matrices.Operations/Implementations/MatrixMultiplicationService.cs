using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Operations.Interfaces;

namespace Matrices.Operations.Implementations
{
    internal class MatrixMultiplicationService : IMatrixMultiplicationService
    {
        public Matrix Multiply(Matrix matrix, double number)
        {
            if (matrix == null) throw new ArgumentException($"The {nameof(matrix)} can not be null");

            var numberOfRows = matrix.M;
            var numberOfColumns = matrix.M;
            var result = new Matrix(numberOfRows, numberOfColumns);

            for (var i = 1; i <= numberOfRows; i++)
            {
                for (var j = 1; j <= numberOfColumns; j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }

        public Matrix Multiply(Matrix first, Matrix second)
        {
            throw new System.NotImplementedException();
        }
    }
}
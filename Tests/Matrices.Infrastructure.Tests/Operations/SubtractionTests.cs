using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations
{
    public class SubtractionTests
    {
        private readonly Subtraction _subtraction = new Subtraction();

        [Theory]
        [MemberData(nameof(OperationData.ArgumentNullExceptionData), MemberType = typeof(OperationData))]
        public void Subtract_When_AnyMatrixIsNull_Throws_ArgumentNullException(Matrix matrixA, Matrix matrixB)
        {
            Func<Matrix> func = () => _subtraction.Subtract(matrixA, matrixB);

            Assert.Throws<ArgumentNullException>(func);
        }

        [Theory]
        [MemberData(nameof(OperationData.MatricesWithDifferentSizes), MemberType = typeof(OperationData))]
        public void Subtract_When_SizesAreNotEqual_Throws_ArgumentException(Matrix matrixA, Matrix matrixB)
        {
            Func<Matrix> func = () => _subtraction.Subtract(matrixA, matrixB);

            Assert.Throws<ArgumentException>(func);
        }

        [Theory]
        [MemberData(nameof(MatrixSubtractionData))]
        public void Subtract_When_MatrixAAndMatrixBIsValid_ReturnsMatrixC(Matrix matrixA, Matrix matrixB, Matrix expected)
        {
            var matrixC = _subtraction.Subtract(matrixA, matrixB);

            Assert.NotNull(matrixC);
            Assert.Equal(expected, matrixC, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MatrixSubtractionData()
        {
            yield return new object[]
            {
                new Matrix(new double[][] {new double[] {10, 9}, new double[] {8, 6}, new double[] {2, 8}}),
                new Matrix(new double[][] {new double[] {3, 10}, new double[] {5, 8}, new double[] {1, 1}}),
                new Matrix(new double[][] {new double[] {7, -1}, new double[] {3, -2}, new double[] {1, 7}})
            };
            yield return new object[]
            {
                new Matrix(new double[][] {new double[] {10, 10, 10}, new double[] {10, 10, 10}, new double[] {10, 10, 10}}),
                new Matrix(new double[][] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                new Matrix(new double[][] {new double[] {9, 8, 7}, new double[] {9, 8, 7}, new double[] {9, 8, 7}})
            };
        }
    }
}

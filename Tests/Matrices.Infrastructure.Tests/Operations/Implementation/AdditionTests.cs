using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class AdditionTests
    {
        private readonly Addition _addition = new Addition();

        [Theory]
        [MemberData(nameof(OperationData.ArgumentNullExceptionData), MemberType = typeof(OperationData))]
        public void Add_When_AnyMatrixIsNull_Throws_ArgumentNullException(Matrix matrixA, Matrix matrixB)
        {
            Func<Matrix> func = () => _addition.Add(matrixA, matrixB);

            Assert.Throws<ArgumentNullException>(func);
        }

        [Theory]
        [MemberData(nameof(OperationData.MatricesWithDifferentSizes), MemberType = typeof(OperationData))]
        public void Add_When_SizesAreNotEqual_Throws_ArgumentException(Matrix matrixA, Matrix matrixB)
        {
            Func<Matrix> func = () => _addition.Add(matrixA, matrixB);

            Assert.Throws<ArgumentException>(func);
        }

        [Theory]
        [MemberData(nameof(MatrixAdditionData))]
        public void Add_When_MatrixAAndMatrixBIsValid_Returns_MatrixC(Matrix matrixA, Matrix matrixB, Matrix expected)
        {
            var matrixC = _addition.Add(matrixA, matrixB);

            Assert.NotNull(matrixC);
            Assert.Equal(expected, matrixC, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MatrixAdditionData()
        {
            yield return new object[]
            {
                new Matrix(new double[][] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new Matrix(new double[][] {new double[] {1, 1}, new double[] {1, 1}, new double[] {1, 1}}),
                new Matrix(new double[][] {new double[] {2, 3}, new double[] {4, 5}, new double[] {6, 7}})
            };
            yield return new object[]
            {
                new Matrix(new double[][] {new double[] {10, 10, 10}, new double[] {10, 10, 10}, new double[] {10, 10, 10}}),
                new Matrix(new double[][] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                new Matrix(new double[][] {new double[] {11, 12, 13}, new double[] {11, 12, 13}, new double[] {11, 12, 13}})
            };
        }
    }
}

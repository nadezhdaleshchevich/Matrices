using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Core.Services;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.IntegrationTests.Operations
{
    public class SubtractionIntegrationTests
    {
        private readonly Subtraction _addition;

        public SubtractionIntegrationTests()
        {
            _addition = new Subtraction(
                new MatrixFactory());
        }

        [Theory]
        [MemberData(nameof(MatrixWithSameSizes))]
        public void Subtract_When_MatrixSizesAreSame_Returns_ExpectedMatrix(Matrix matrixA, Matrix matrixB, Matrix expected)
        {
            var actual = _addition.Subtract(matrixA, matrixB);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MatrixWithSameSizes()
        {
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {10, 9}, new double[] {8, 6}, new double[] {2, 8}}),
                new RectangularMatrix(new [] {new double[] {3, 10}, new double[] {5, 8}, new double[] {1, 1}}),
                new RectangularMatrix(new [] {new double[] {7, -1}, new double[] {3, -2}, new double[] {1, 7}})
            };
            yield return new object[]
            {
                new SquareMatrix(new [] {new double[] {10, 10, 10}, new double[] {10, 10, 10}, new double[] {10, 10, 10}}),
                new SquareMatrix(new [] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                new SquareMatrix(new [] {new double[] {9, 8, 7}, new double[] {9, 8, 7}, new double[] {9, 8, 7}})
            };
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {10, 10, 10}, new double[] {10, 10, 10}, new double[] {10, 10, 10}}),
                new RectangularMatrix(new [] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                new SquareMatrix(new [] {new double[] {9, 8, 7}, new double[] {9, 8, 7}, new double[] {9, 8, 7}})
            };
        }
    }
}

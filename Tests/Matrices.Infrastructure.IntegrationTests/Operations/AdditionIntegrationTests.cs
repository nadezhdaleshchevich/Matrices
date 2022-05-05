using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Core.Services;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.IntegrationTests.Operations
{
    public class AdditionIntegrationTests
    {
        private readonly Addition _addition;

        public AdditionIntegrationTests()
        {
            _addition = new Addition(
                new MatrixFactory());
        }

        [Theory]
        [MemberData(nameof(MatrixWithSameSizes))]
        public void Add_When_MatrixSizesAreSame_Returns_ExpectedMatrix(Matrix matrixA, Matrix matrixB, Matrix expected)
        {
            var actual = _addition.Add(matrixA, matrixB);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MatrixWithSameSizes()
        {
            yield return new object[]
            {
                new RectangularMatrix(new[] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new RectangularMatrix(new[] {new double[] {1, 1}, new double[] {1, 1}, new double[] {1, 1}}),
                new RectangularMatrix(new[] {new double[] {2, 3}, new double[] {4, 5}, new double[] {6, 7}})
            };
            yield return new object[]
            {
                new SquareMatrix(new[] {new double[] {10, 10, 10}, new double[] {10, 10, 10}, new double[] {10, 10, 10}}),
                new SquareMatrix(new[] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                new SquareMatrix(new[] {new double[] {11, 12, 13}, new double[] {11, 12, 13}, new double[] {11, 12, 13}})
            };
            yield return new object[]
            {
                new RectangularMatrix(new[] {new double[] {10, 10, 10}, new double[] {10, 10, 10}, new double[] {10, 10, 10}}),
                new RectangularMatrix(new[] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                new SquareMatrix(new[] {new double[] {11, 12, 13}, new double[] {11, 12, 13}, new double[] {11, 12, 13}})
            };
        }
    }
}
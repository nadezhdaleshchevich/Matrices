using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Core.Services;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.IntegrationTests.Operations
{
    public class TranspositionIntegrationTests
    {
        private readonly Transposition _transposition;

        public TranspositionIntegrationTests()
        {
            _transposition = new Transposition(
                new MatrixFactory());
        }

        [Theory]
        [MemberData(nameof(MatrixIsValidData))]
        public void Transpose_When_MatrixIsValid_Returns_TransformedMatrix(Matrix matrixA, Matrix expected)
        {
            var actual = _transposition.Transpose(matrixA);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MatrixIsValidData()
        {
            yield return new object[]
            {
                new RectangularMatrix(new double[][] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new RectangularMatrix(new double[][] {new double[] {1, 3, 5}, new double[] {2, 4, 6} }),
            };

            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {-1, 1, 1}, new double[] {2, -2, 2}, new double[] {3, 3, -3}}),
                new SquareMatrix(new double[][] {new double[] {-1, 2, 3}, new double[] {1, -2, 3}, new double[] {1, 2, -3}}),
            };
        }
    }
}

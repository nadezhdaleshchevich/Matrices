using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Core.Services;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.IntegrationTests.Operations
{
    public class MultiplicationIntegrationTests
    {
        private readonly Multiplication _multiplication;

        public MultiplicationIntegrationTests()
        {
            _multiplication = new Multiplication(
                new MatrixFactory());
        }

        [Theory]
        [MemberData(nameof(MultiplicationOfMatrixByNumberData))]
        public void Multiply_MatrixByNumber_When_MatrixIsValid_Returns_ExpectedMatrix(Matrix matrixA, double number, Matrix expected)
        {
            var actual = _multiplication.Multiply(matrixA, number);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MultiplicationOfMatrixByNumberData()
        {
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {10, -9}, new double[] {-8, 6}, new double[] {-2, 8}}),
                10,
                new RectangularMatrix(new [] {new double[] {100, -90}, new double[] {-80, 60}, new double[] {-20, 80}})
            };
            yield return new object[]
            {
                new SquareMatrix(new [] {new double[] {10, -5, 10}, new double[] {-8, -10, -1}, new double[] {2, -2, 7}}),
                -2,
                new SquareMatrix(new [] {new double[] {-20, 10, -20}, new double[] {16, 20, 2}, new double[] {-4, 4, -14}})
            };
        }

        [Theory]
        [MemberData(nameof(MultiplicationOfMatrixByMatrixData))]
        public void Multiply_MatrixByMatrix_When_MatricesAreValid_Returns_ExpectedMatrix(Matrix matrixA, Matrix matrixB, Matrix expected)
        {
            var actual = _multiplication.Multiply(matrixA, matrixB);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MultiplicationOfMatrixByMatrixData()
        {
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {4, 3, -1}, new double[] {2, -9, 5}}),
                new RectangularMatrix(new [] {new double[] {-6, 3, 1}, new double[] {7, -1, -2}, new double[] {-3, 8, 2}}),
                new RectangularMatrix(new [] {new double[] {0 , 1, -4}, new double[] {-90, 55, 30}})
            };
            yield return new object[]
            {
                new SquareMatrix(new [] {new double[] {-10, -2, 5}, new double[] {7, -9, 3}, new double[] {0, 0, 7} }),
                new SquareMatrix(new [] {new double[] {1, 8, -3}, new double[] {-5, -9, 0}, new double[] {4, -1, 5} }),
                new SquareMatrix(new [] {new double[] {20, -67, 55}, new double[] {64, 134, -6}, new double[] {28, -7, 35} })
            };
        }
    }
}

using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class AlgebraicAdditionTests
    {
        private readonly AlgebraicAddition _algebraicAddition = new AlgebraicAddition();

        [Fact]
        public void Create_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;
            int row = 1;
            int column = 1;

            Action action = () => _algebraicAddition.Create(matrixA, row, column);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Create_When_NIsLessThanThree_Throws_ArgumentException(int n)
        {
            SquareMatrix matrixA = new SquareMatrix(n);
            int row = 1;
            int column = 1;

            Action action = () => _algebraicAddition.Create(matrixA, row, column);

            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [InlineData(3, 0, 1)]
        [InlineData(4, 1, 5)]
        public void Create_When_RowOrColumnIsLessThanOneOrMoreThanN_Throws_ArgumentOutOfRangeException(int n, int row, int column)
        {
            SquareMatrix matrixA = new SquareMatrix(n);

            Action action = () => _algebraicAddition.Create(matrixA, row, column);

            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [MemberData(nameof(MatrixIsValidData))]
        public void Create_When_MatrixIsValid_Returns_AlgebraicAddition(SquareMatrix matrixA, int row, int column, SquareMatrix expected)
        {
            var actual = _algebraicAddition.Create(matrixA, row, column);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> MatrixIsValidData()
        {
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {1, 2, 3, 4}, new double[] {-1, -2, -3, -4}, new double[] {1, 2, 3, 4}, new double[] {-1, -2, -3, -4}}),
                1,
                1,
                new SquareMatrix(new double[][] {new double[] {-2, -3, -4}, new double[] {2, 3, 4}, new double[] {-2, -3, -4}})
            };
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {1, 2, 3, 4}, new double[] {-1, -2, -3, -4}, new double[] {1, 2, 3, 4}, new double[] {-1, -2, -3, -4}}),
                1,
                4,
                new SquareMatrix(new double[][] {new double[] {-1, -2, -3}, new double[] {1, 2, 3}, new double[] {-1, -2, -3}}),
            };
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {-7, -6, -5, -4}, new double[] {-3, -2, -1, 0}, new double[] {1, 2, 3, 4}, new double[] {5, 6, 7, 8}}),
                3,
                3,
                new SquareMatrix(new double[][] {new double[] {-7, -6, -4}, new double[] {-3, -2, 0}, new double[] {5, 6, 8}})
            };
        }
    }
}

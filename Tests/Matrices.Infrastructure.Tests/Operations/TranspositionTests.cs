using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations
{
    public class TranspositionTests
    {
        private readonly Transposition  _transposition = new Transposition();

        [Fact]
        public void Transpose_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            Matrix matrixA = null;

            Func<Matrix> func = () => _transposition.Transpose(matrixA);

            Assert.Throws<ArgumentNullException>(() => func());
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
                new Matrix(new double[][] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new Matrix(new double[][] {new double[] {1, 3, 5}, new double[] {2, 4, 6} }),
            };

            yield return new object[]
            {
                new Matrix(new double[][] {new double[] {-1, 1, 1}, new double[] {2, -2, 2}, new double[] {3, 3, -3}}),
                new Matrix(new double[][] {new double[] {-1, 2, 3}, new double[] {1, -2, 3}, new double[] {1, 2, -3}}),
            };
        }
    }
}

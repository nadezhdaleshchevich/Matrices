using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Moq;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class MatrixEqualityComparerTests
    {
        private readonly MatrixEqualityComparer _matrixEqualityComparer = new MatrixEqualityComparer();

        private readonly Mock<Matrix> _mockMatrixMock = new Mock<Matrix>(MockBehavior.Strict, 1, 1);

        [Theory]
        [MemberData(nameof(Data))]
        public void Equals_AnyMatrices_ExpectedResult(Matrix matrixA, Matrix matrixB, bool expected)
        {
            var actual = _matrixEqualityComparer.Equals(matrixA, matrixB);

            Assert.Equal(expected, actual);
        }
        
        public static IEnumerable<object[]> Data()
        {
            yield return new object[]
            {
                null,
                null,
                true
            };
            yield return new object[]
            {
                new RectangularMatrix(5, 3),
                null,
                false
            };
            yield return new object[]
            {
                null,
                new RectangularMatrix(3, 2),
                false
            };
            yield return new object[]
            {
                new RectangularMatrix(3, 3),
                new SquareMatrix(3),
                false
            };
            yield return new object[]
            {
                new RectangularMatrix(3, 2),
                new RectangularMatrix(3, 3),
                false
            };
            yield return new object[]
            {
                new RectangularMatrix(3, 2),
                new RectangularMatrix(3, 2),
                true
            };
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new RectangularMatrix(new [] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                true
            };
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new RectangularMatrix(new [] {new double[] {0.9, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                false
            };
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new RectangularMatrix(new [] {new double[] {0.99999999999, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                false
            };
            yield return new object[]
            {
                new RectangularMatrix(new [] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                new RectangularMatrix(new [] {new double[] { 0.999999999999, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                true
            };
        }

        [Fact]
        public void GetHashCode_AnyMatrix_Returns_ExpectedHashCode()
        {
            int hashCode = 10;

            _mockMatrixMock.Setup(m => m.GetHashCode()).Returns(hashCode);

            int actual = _matrixEqualityComparer.GetHashCode(_mockMatrixMock.Object);

            Assert.Equal(hashCode, actual);

            _mockMatrixMock.Verify(m => m.GetHashCode(), Times.Once);
        }
    }
}

using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Moq;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class TranspositionTests
    {
        private readonly Transposition _transposition;

        private readonly Mock<IMatrixFactory> _mockMatrixFactory = new Mock<IMatrixFactory>();

        public TranspositionTests()
        {
            _mockMatrixFactory
                .Setup(m => m.CreateMatrix(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int m, int n) => new RectangularMatrix(m, n));

            _transposition = new Transposition(
                _mockMatrixFactory.Object);
        }

        [Fact]
        public void Transpose_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            Matrix matrixA = null;

            Action action = () => _transposition.Transpose(matrixA);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [MemberData(nameof(Matrices))]
        public void Transpose_When_MatrixIsValid_Returns_TransposedMatrix_MatrixFactoryAreCalled(Matrix matrixA)
        {
            var actual = _transposition.Transpose(matrixA);

            Assert.NotNull(actual);
            Assert.NotSame(matrixA, actual);

            _mockMatrixFactory
                .Verify(m => m.CreateMatrix(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        public static IEnumerable<object[]> Matrices()
        {
            yield return new object[] { new RectangularMatrix(3, 1) };
            yield return new object[] { new RectangularMatrix(5, 2) };
            yield return new object[] { new SquareMatrix(7) };
        }
    }
}

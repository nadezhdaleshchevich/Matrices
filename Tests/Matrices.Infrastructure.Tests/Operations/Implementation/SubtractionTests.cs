using System;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Moq;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class SubtractionTests
    {
        private readonly Subtraction _subtraction;

        private readonly Mock<IMatrixFactory> _mockMatrixFactory = new Mock<IMatrixFactory>();

        public SubtractionTests()
        {
            _mockMatrixFactory
                .Setup(m => m.CreateMatrix(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int m, int n) => new RectangularMatrix(m, n));

            _subtraction = new Subtraction(
                _mockMatrixFactory.Object);
        }

        [Theory]
        [MemberData(nameof(OperationData.ArgumentNullExceptionData), MemberType = typeof(OperationData))]
        public void Subtract_When_AnyMatrixIsNull_Throws_ArgumentNullException(Matrix matrixA, Matrix matrixB)
        {
            Action action = () => _subtraction.Subtract(matrixA, matrixB);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [MemberData(nameof(OperationData.MatricesWithDifferentSizes), MemberType = typeof(OperationData))]
        public void Subtract_When_MatrixSizesAreDifferent_Throws_ArgumentException(Matrix matrixA, Matrix matrixB)
        {
            Action action = () => _subtraction.Subtract(matrixA, matrixB);

            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [MemberData(nameof(OperationData.MatricesWithSameSizes), MemberType = typeof(OperationData))]
        public void Subtract_When_MatrixSizesAreSame_Returns_NewMatrix_MatrixFactoryAreCalled(Matrix matrixA, Matrix matrixB)
        {
            var actual = _subtraction.Subtract(matrixA, matrixB);

            Assert.NotNull(actual);
            Assert.NotSame(matrixA, actual);
            Assert.NotSame(matrixB, actual);

            _mockMatrixFactory
                .Verify(m => m.CreateMatrix(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}

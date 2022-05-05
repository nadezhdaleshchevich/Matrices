using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Moq;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class MultiplicationTests
    {
        private readonly Multiplication _multiplication;

        private readonly Mock<IMatrixFactory> _mockMatrixFactory = new Mock<IMatrixFactory>();

        public MultiplicationTests()
        {
            _mockMatrixFactory
                .Setup(m => m.CreateMatrix(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int m, int n) => new RectangularMatrix(m, n));

            _multiplication = new Multiplication(
                _mockMatrixFactory.Object);
        }

        [Fact]
        public void Multiply_MatrixByNumber_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            Matrix matrixA = null;
            double number = 10.0;

            Action action = () => _multiplication.Multiply(matrixA, number);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [MemberData(nameof(MultiplicationOfMatrixByNumberData))]
        public void Multiply_MatrixByNumber_When_MatrixIsValid_Returns_NewMatrix_MatrixFactoryIsCalled(Matrix matrixA, double number)
        {
            var actual = _multiplication.Multiply(matrixA, number);

            Assert.NotNull(actual);
            Assert.NotSame(matrixA, actual);
        }

        public static IEnumerable<object[]> MultiplicationOfMatrixByNumberData()
        {
            yield return new object[]
            {
                new RectangularMatrix(3, 2),
                10,
            };
            yield return new object[]
            {
                new SquareMatrix(3),
                -2,
            };
        }

        [Theory]
        [MemberData(nameof(OperationData.ArgumentNullExceptionData), MemberType = typeof(OperationData))]
        public void Multiply_MatrixByMatrix_When_AnyMatrixIsNull_Throws_ArgumentNullException(Matrix matrixA, Matrix matrixB)
        {
            Action action = () => _multiplication.Multiply(matrixA, matrixB);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [MemberData(nameof(MatrixSizesAreNotCorrectData))]
        public void Multiply_When_MatrixSizesAreNotCorrect_Throws_ArgumentException(Matrix matrixA, Matrix matrixB)
        {
            Action action = () => _multiplication.Multiply(matrixA, matrixB);

            Assert.Throws<ArgumentException>(action);
        }

        public static IEnumerable<object[]> MatrixSizesAreNotCorrectData()
        {
            yield return new object[]
            {
                new RectangularMatrix(3, 4),
                new RectangularMatrix(3, 4)
            };
            yield return new object[]
            {
                new RectangularMatrix(5, 4),
                new RectangularMatrix(1, 4)
            };
        }

        [Theory]
        [MemberData(nameof(MatrixSizesAreCorrectData))]
        public void Multiply_When_MatrixSizesAreCorrect_Returns_NewMatrix_MatrixFactoryIsCalled(Matrix matrixA, Matrix matrixB)
        {
            var actual = _multiplication.Multiply(matrixA, matrixB);

            Assert.NotNull(actual);
            Assert.NotSame(matrixA, actual);
            Assert.NotSame(matrixB, actual);

            _mockMatrixFactory
                .Verify(m => m.CreateMatrix(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        public static IEnumerable<object[]> MatrixSizesAreCorrectData()
        {
            yield return new object[]
            {
                new RectangularMatrix(5, 2),
                new RectangularMatrix(2, 7),
            };
            yield return new object[]
            {
                new SquareMatrix(3),
                new SquareMatrix(3),
            };
        }
    }
}

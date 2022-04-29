using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Operations.Interfaces;
using Moq;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class DeterminantCalculatorTests
    {
        private readonly DeterminantCalculator _determinantCalculator;

        private readonly Mock<IDeterminantFor1X1Calculator> _mockDeterminantFor1X1Calculator;
        private readonly Mock<IDeterminantFor2X2Calculator> _mockDeterminantFor2X2Calculator;
        private readonly Mock<IDeterminantFor3X3Calculator> _mockDeterminantFor3X3Calculator;
        private readonly Mock<IAlgebraicAddition> _mockAlgebraicAddition;

        public DeterminantCalculatorTests()
        {
            _mockDeterminantFor1X1Calculator = new Mock<IDeterminantFor1X1Calculator>();
            _mockDeterminantFor2X2Calculator = new Mock<IDeterminantFor2X2Calculator>();
            _mockDeterminantFor3X3Calculator = new Mock<IDeterminantFor3X3Calculator>();
            _mockAlgebraicAddition = new Mock<IAlgebraicAddition>();

            SetupMock();

            _determinantCalculator = new DeterminantCalculator(
                _mockDeterminantFor1X1Calculator.Object,
                _mockDeterminantFor2X2Calculator.Object,
                _mockDeterminantFor3X3Calculator.Object,
                _mockAlgebraicAddition.Object);
        }

        private void SetupMock()
        {
            _mockDeterminantFor1X1Calculator.Setup(m => m.Calculate(It.IsAny<SquareMatrix>()))
                .Returns(0);

            _mockDeterminantFor2X2Calculator.Setup(m => m.Calculate(It.IsAny<SquareMatrix>()))
                .Returns(0);

            _mockDeterminantFor3X3Calculator.Setup(m => m.Calculate(It.IsAny<SquareMatrix>()))
                .Returns(0);

            _mockAlgebraicAddition.Setup(m => m.Create(It.IsAny<SquareMatrix>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns((SquareMatrix matrix, int row, int column) => new SquareMatrix(matrix.N - 1));
        }

        [Fact]
        public void Calculate_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;

            Func<double> func = () => _determinantCalculator.Calculate(matrixA);

            Assert.Throws<ArgumentNullException>(() => func());

            _mockDeterminantFor1X1Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor2X2Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor3X3Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockAlgebraicAddition.Verify(m => m.Create(It.IsAny<SquareMatrix>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void Calculate_When_NIsOne_DeterminantFor1X1CalculatorIsCalled()
        {
            var matrixA = new SquareMatrix(1);

            double det = _determinantCalculator.Calculate(matrixA);

            _mockDeterminantFor1X1Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Once);
            _mockDeterminantFor2X2Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor3X3Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockAlgebraicAddition.Verify(m => m.Create(It.IsAny<SquareMatrix>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void Calculate_When_NIsTwo_DeterminantFor2X2CalculatorIsCalled()
        {
            var matrixA = new SquareMatrix(2);

            double det = _determinantCalculator.Calculate(matrixA);

            _mockDeterminantFor1X1Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor2X2Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Once);
            _mockDeterminantFor3X3Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockAlgebraicAddition.Verify(m => m.Create(It.IsAny<SquareMatrix>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void Calculate_When_NIsThree_DeterminantFor3X3CalculatorIsCalled()
        {
            var matrixA = new SquareMatrix(3);

            double det = _determinantCalculator.Calculate(matrixA);

            _mockDeterminantFor1X1Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor2X2Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor3X3Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Once);
            _mockAlgebraicAddition.Verify(m => m.Create(It.IsAny<SquareMatrix>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void Calculate_When_NIsFour_DeterminantFor3X3CalculatorAndAlgebraicAdditionAreCalled()
        {
            var matrixA = new SquareMatrix(4);

            double det = _determinantCalculator.Calculate(matrixA);

            _mockDeterminantFor1X1Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor2X2Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.Never);
            _mockDeterminantFor3X3Calculator.Verify(m => m.Calculate(It.IsAny<SquareMatrix>()), Times.AtLeastOnce);
            _mockAlgebraicAddition.Verify(m => m.Create(It.IsAny<SquareMatrix>(), It.IsAny<int>(), It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}

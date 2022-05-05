using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class DeterminantFor2X2CalculatorTests
    {
        private readonly DeterminantFor2X2Calculator _determinantFor2X2Calculator = new DeterminantFor2X2Calculator();

        [Fact]
        public void Calculate_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;

            Action action = () => _determinantFor2X2Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(10)]
        public void Calculate_When_NIsNotEqualTwo_Throws_ArgumentException(int n)
        {
            var matrixA = new SquareMatrix(n);

            Action action = () => _determinantFor2X2Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [MemberData(nameof(DeterminantCalculatorData.Matrix2X2Data), MemberType = typeof(DeterminantCalculatorData))]
        public void Calculate_When_MatrixIsValid_Returns_Determinant(SquareMatrix matrixA, double expected)
        {
            var actual =  _determinantFor2X2Calculator.Calculate(matrixA);

            Assert.Equal(expected, actual);
        }
    }
}

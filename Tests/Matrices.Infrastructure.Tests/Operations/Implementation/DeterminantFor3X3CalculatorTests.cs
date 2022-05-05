using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class DeterminantFor3X3CalculatorTests
    {
        private readonly DeterminantFor3X3Calculator _determinantFor3X3Calculator = new DeterminantFor3X3Calculator();

        [Fact]
        public void Calculate_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;

            Action action = () => _determinantFor3X3Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void Calculate_When_NIsNotEqualThree_Throws_ArgumentException(int n)
        {
            var matrixA = new SquareMatrix(n);

            Action action = () => _determinantFor3X3Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [MemberData(nameof(DeterminantCalculatorData.Matrix3X3Data), MemberType = typeof(DeterminantCalculatorData))]
        public void Calculate_When_MatrixIsValid_Returns_Determinant(SquareMatrix matrixA, double expected)
        {
            var actual =  _determinantFor3X3Calculator.Calculate(matrixA);

            Assert.Equal(expected, actual);
        }
    }
}

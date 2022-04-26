using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations
{
    public class DeterminantFor3X3CalculatorTests
    {
        private readonly DeterminantFor3X3Calculator _determinantFor3X3Calculator = new DeterminantFor3X3Calculator();

        [Fact]
        public void Calculate_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;

            Func<double> func = () => _determinantFor3X3Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentNullException>(() => func());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void Calculate_When_NIsNotEqualThree_Throws_ArgumentException(int n)
        {
            var matrixA = new SquareMatrix(n);

            Func<double> func = () => _determinantFor3X3Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentException>(() => func());
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

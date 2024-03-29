﻿using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
{
    public class DeterminantFor1X1CalculatorTests
    {
        private readonly DeterminantFor1X1Calculator _determinantFor1X1Calculator = new DeterminantFor1X1Calculator();

        [Fact]
        public void Calculate_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;

            Action action = () => _determinantFor1X1Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(10)]
        public void Calculate_When_NIsNotEqualOne_Throws_ArgumentException(int n)
        {
            var matrixA = new SquareMatrix(n);

            Action action = () => _determinantFor1X1Calculator.Calculate(matrixA);

            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [MemberData(nameof(DeterminantCalculatorData.Matrix1X1Data), MemberType = typeof(DeterminantCalculatorData))]
        public void Calculate_When_MatrixIsValid_Returns_Determinant(SquareMatrix matrixA, double expected)
        {
            var actual =  _determinantFor1X1Calculator.Calculate(matrixA);

            Assert.Equal(expected, actual);
        }
    }
}

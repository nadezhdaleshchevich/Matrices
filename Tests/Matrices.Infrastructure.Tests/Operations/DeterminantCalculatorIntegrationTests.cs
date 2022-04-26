using System;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations
{
    public class DeterminantCalculatorIntegrationTests
    {
        private readonly DeterminantCalculator _determinantCalculator;

        public DeterminantCalculatorIntegrationTests()
        {
            _determinantCalculator = new DeterminantCalculator(
                new DeterminantFor1X1Calculator(),
                new DeterminantFor2X2Calculator(),
                new DeterminantFor3X3Calculator(),
                new AlgebraicAddition());
        }

        [Fact]
        public void Calculate_When_MatrixIsNull_Throws_ArgumentNullException()
        {
            SquareMatrix matrixA = null;

            Func<double> func = () => _determinantCalculator.Calculate(matrixA);

            Assert.Throws<ArgumentNullException>(() => func());
        }

        [Theory]
        [MemberData(nameof(DeterminantCalculatorData.Matrix1X1Data), MemberType = typeof(DeterminantCalculatorData))]
        [MemberData(nameof(DeterminantCalculatorData.Matrix2X2Data), MemberType = typeof(DeterminantCalculatorData))]
        [MemberData(nameof(DeterminantCalculatorData.Matrix3X3Data), MemberType = typeof(DeterminantCalculatorData))]
        public void Calculate_When_MatrixIsValid_Returns_Determinant(SquareMatrix matrixA, double expected)
        {
            var actual = _determinantCalculator.Calculate(matrixA);

            Assert.Equal(expected, actual);
        }
    }
}

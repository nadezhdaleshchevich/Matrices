using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Tests.Operations.Implementation.Data;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Implementation
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
        [MemberData(nameof(MatrixData))]
        public void Calculate_When_MatrixIsValid_Returns_Determinant(SquareMatrix matrixA, double expected)
        {
            var actual = _determinantCalculator.Calculate(matrixA);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> MatrixData()
        {
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {1, 9, 7, 2}, new double[] {7, -3, 3, 2}, new double[] {4, 8, 2, 5}, new double[] {4, 2, 9, 5}}),
                2010
            };
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {1, 9, 7, 2, 4}, new double[] {7, -3, 3, 2, 0}, new double[] {4, 8, 2, 5, 3}, new double[] {4, 2, 9, 5, 9}, new double[] {5, 7, 1, 2, 4}}),
                12800
            };
        }
    }
}

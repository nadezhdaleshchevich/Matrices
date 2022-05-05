using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.IntegrationTests.Operations.Data
{
    public static class DeterminantCalculatorData
    {
        public static IEnumerable<object[]> Matrix1X1Data()
        {
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {5}}),
                5
            };
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {-10}}),
                -10
            };
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {0}}),
                0
            };
        }

        public static IEnumerable<object[]> Matrix2X2Data()
        {
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {1, 2}, new double[] {1, 2}}),
                0
            };

            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {-10, 2}, new double[] {-1, 6}}),
                -58
            };
        }

        public static IEnumerable<object[]> Matrix3X3Data()
        {
            yield return new object[]
            {
                new SquareMatrix(new double[][] {new double[] {-10, -2, 5}, new double[] {7, -9, 3}, new double[] { 0, 0, 7 } }),
                728
            };
            yield return new object[]
            {
                new SquareMatrix(new double[][] { new double[] { 1, 8, -3 }, new double[] { -5, -9, 0 }, new double[] { 4, -1, 5 } }),
                32
            };
        }
    }
}

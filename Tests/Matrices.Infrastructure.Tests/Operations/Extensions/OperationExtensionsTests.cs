using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Extensions;
using Matrices.Infrastructure.Operations.Implementation;
using Xunit;

namespace Matrices.Infrastructure.Tests.Operations.Extensions
{
    public class OperationExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ArgumentNullExceptionData))]
        public void ForEach_When_MatrixOrFuncIsNull_Throw_ArgumentNullException(Matrix matrix, Func<int, int, double> func)
        {
            Action action = () => OperationExtensions.ForEach(matrix, func);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [MemberData(nameof(MatrixAndFunc))]
        public void ForEach_When_MatrixAndFuncAreValid_MatrixIsChanged(Matrix matrix, Func<int, int, double> func, Matrix ex)
        {
            OperationExtensions.ForEach(matrix, func);

            Assert.Equal(ex, matrix, new MatrixEqualityComparer());
        }

        public static IEnumerable<object[]> ArgumentNullExceptionData()
        {
            yield return new object[] { null, null };
            yield return new object[] { new RectangularMatrix(4, 6), null };
            yield return new object[] { new SquareMatrix(3), null };
            yield return new object[] { null, (Func<int, int, double>)((i, j) => 1.0) };
        }

        public static IEnumerable<object[]> MatrixAndFunc()
        {
            yield return new object[]
            {
                new RectangularMatrix(new[] {new double[] {1, 2}, new double[] {3, 4}, new double[] {5, 6}}),
                (Func<int, int, double>)((i, j) => 1),
                new RectangularMatrix(new[] {new double[] {1, 1}, new double[] {1, 1}, new double[] {1, 1}})
            };
            yield return new object[]
            {
                new SquareMatrix(new [] {new double[] {1, 2, 3}, new double[] {1, 2, 3}, new double[] {1, 2, 3}}),
                (Func<int, int, double>)((i, j) => -5),
                new SquareMatrix(new [] {new double[] {-5, -5, -5}, new double[] {-5, -5, -5}, new double[] {-5, -5, -5} })
            };
        }
    }
}

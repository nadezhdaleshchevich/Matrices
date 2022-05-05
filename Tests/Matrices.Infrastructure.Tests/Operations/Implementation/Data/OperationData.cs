using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Tests.Operations.Implementation.Data
{
    public class OperationData
    {
        public static IEnumerable<object[]> ArgumentNullExceptionData()
        {
            yield return new object[] { null, null };
            yield return new object[] { new RectangularMatrix(1, 2), null };
            yield return new object[] { null, new RectangularMatrix(1, 2) };
            yield return new object[] { new SquareMatrix(1), null };
            yield return new object[] { null, new SquareMatrix(1) };
        }

        public static IEnumerable<object[]> MatricesWithDifferentSizes()
        {
            yield return new object[] { new RectangularMatrix(2, 3), new RectangularMatrix(3, 2) };
            yield return new object[] { new RectangularMatrix(2, 7), new RectangularMatrix(3, 9) };
        }

        public static IEnumerable<object[]> MatricesWithSameSizes()
        {
            yield return new object[] { new RectangularMatrix(5, 3), new RectangularMatrix(5, 3) };
            yield return new object[] { new SquareMatrix(6), new SquareMatrix(6) };
        }
    }
}

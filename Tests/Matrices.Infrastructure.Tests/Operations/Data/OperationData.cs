using System.Collections.Generic;
using Matrices.Infrastructure.Models;

namespace Matrices.Infrastructure.Tests.Operations.Data
{
    public class OperationData
    {
        public static IEnumerable<object[]> ArgumentNullExceptionData()
        {
            yield return new object[] { null, new Matrix(1, 1) };
            yield return new object[] { new Matrix(1, 1), null };
            yield return new object[] { null, null };
        }

        public static IEnumerable<object[]> MatricesWithDifferentSizes()
        {
            yield return new object[] { new Matrix(2, 3), new Matrix(3, 2) };
            yield return new object[] { new Matrix(2, 7), new Matrix(3, 9) };
        }
    }
}

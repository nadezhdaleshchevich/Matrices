using System;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Operations.Extensions
{
    internal static class OperationExtensions
    {
        public static void ForEach(this Matrix matrix, Func<int, int, double> func)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (func == null) throw new ArgumentNullException(nameof(func));

            for (int i = 1; i <= matrix.M; i++)
            {
                for (int j = 1; j <= matrix.N; j++)
                {
                    matrix[i, j] = func(i, j);
                }
            }
        }
    }
}

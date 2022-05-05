using System;
using System.Collections.Generic;
using System.Linq;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Core.Services
{
    internal class MatrixFactory : IMatrixFactory
    {
        public Matrix CreateMatrix(int m, int n)
        {
            if (n < 1) throw new ArgumentException($"The {nameof(n)} can not be less than 1.");
            if (m < 1) throw new ArgumentException($"The {nameof(m)} can not be less than 1.");

            if (m == n)
            {
                return new SquareMatrix(n);
            }

            return new RectangularMatrix(m, n);
        }

        public Matrix CreateMatrix(IEnumerable<double[]> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (source.First() == null) throw new ArgumentNullException(nameof(source));
            if (source.Any(row => row.Length != source.First().Length)) throw new ArgumentException(nameof(source));

            int n = source.Count();
            int m = source.First().Length;

            if (m == n)
            {
                return new SquareMatrix(source);
            }

            return new RectangularMatrix(source);
        }
    }
}

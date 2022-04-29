using System;
using System.Collections.Generic;

namespace Matrices.Infrastructure.Models
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(int n) : base(n, n) { }

        public SquareMatrix(IEnumerable<double[]> source) : base(source)
        {
            if (M != N) throw new ArgumentException(nameof(source));
        }
    }
}

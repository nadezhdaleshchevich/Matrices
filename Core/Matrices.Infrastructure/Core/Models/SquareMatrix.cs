using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Operations.Extensions;

namespace Matrices.Infrastructure.Core.Models
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(int n) : base(n, n) { }

        public SquareMatrix(IEnumerable<double[]> source) : base(source)
        {
            if (M != N) throw new ArgumentException(nameof(source));
        }

        public override object Clone()
        {
            var matrix = new SquareMatrix(N);

            matrix.ForEach((i, j) => this[i, j]);

            return matrix;
        }
    }
}

using System.Collections.Generic;
using Matrices.Infrastructure.Operations.Extensions;

namespace Matrices.Infrastructure.Core.Models
{
    public class RectangularMatrix : Matrix
    {
        public RectangularMatrix(int m, int n) : base(m, n) { }

        public RectangularMatrix(IEnumerable<double[]> source) : base(source) { }

        public override object Clone()
        {
            var matrix = new RectangularMatrix(M, N);

            matrix.ForEach((i, j) => this[i, j]);

            return matrix;
        }
    }
}

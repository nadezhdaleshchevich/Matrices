using System;

namespace Matrices.Infrastructure.Models
{
    public class DiagonalMatrix : SquareMatrix
    {
        public DiagonalMatrix(int n) : base(n) { }

        public override double this[int m, int n]
        {
            set
            {
                if (m != n) throw new ArgumentException($"{nameof(m)} {nameof(n)}");

                base[m, n] = value;
            }
        }
    }
}

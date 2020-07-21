using System;

namespace Matrices.Infrastructure.Core.Models
{
    public class Matrix
    {
        private readonly double[,] _source;

        public Matrix(int n) : this(1, n) { }

        public Matrix(int m, int n)
        {
            if (m < 1)
                throw new ArgumentException($"The {nameof(m)} can not be less than 1.");
            if (n < 1)
                throw new ArgumentException($"The {nameof(n)} can not be less than 1.");

            M = m;
            N = n;
            _source = new double[M, N];
        }

        public int M { get; }
        public int N { get; }

        public double this[int m, int n]
        {
            get
            {
                // TODO
                if (m < 1 || m > M
                    || n < 1 || n > N)
                    throw new ArgumentOutOfRangeException();

                return _source[--m, --n];
            }
            set
            {
                if (m < 1 || m > M
                          || n < 1 || n > N)
                    throw new ArgumentOutOfRangeException();

                _source[--m, --n] = value;
            }
        }
    }
}

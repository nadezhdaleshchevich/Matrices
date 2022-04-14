using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Matrices.Infrastructure.Core.Models
{
    public class Matrix
    {
        private readonly double[][] _source;

        public Matrix(int n) : this(1, n) { }

        public Matrix(int n, int m)
        {
            if (n < 1)
                throw new ArgumentException($"The {nameof(n)} can not be less than 1.");
            if (m < 1)
                throw new ArgumentException($"The {nameof(m)} can not be less than 1.");

            M = m;
            N = n;

            _source = new double[M][];

            for (int i = 0; i < M; i++)
            {
                _source[i] = new double[N];
            }
        }

        public int M { get; }

        public int N { get; }

        public double this[int m, int n]
        {
            get
            {
                if (m < 1 || m > M) throw new ArgumentNullException(nameof(m));
                if (n < 1 || n > N) throw new ArgumentNullException(nameof(n));

                return _source[--m][--n];
            }
            set
            {
                if (m < 1 || m > M) throw new ArgumentNullException(nameof(m));
                if (n < 1 || n > N) throw new ArgumentNullException(nameof(n));

                _source[--m][--n] = value;
            }
        }
    }
}

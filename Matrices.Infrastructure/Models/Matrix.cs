using System;
using System.Collections.Generic;
using System.Linq;
using Matrices.Infrastructure.Operations.Extensions;

namespace Matrices.Infrastructure.Models
{
    public class Matrix : IEquatable<Matrix>
    {
        private readonly double[][] _source;

        public Matrix(int m, int n)
        {
            if (n < 1) throw new ArgumentException($"The {nameof(n)} can not be less than 1.");
            if (m < 1) throw new ArgumentException($"The {nameof(m)} can not be less than 1.");

            M = m;
            N = n;

            _source = new double[M][];

            for (int i = 0; i < M; i++)
            {
                _source[i] = new double[N];
            }
        }

        public Matrix(IEnumerable<double[]> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (source.First() == null) throw new ArgumentNullException(nameof(source));
            if (source.Any(row => row.Length != source.First().Length)) throw new ArgumentException(nameof(source));

            M = source.Count();
            N = source.First().Length;

            _source = new double[M][];

            using (var enumerator = source.GetEnumerator())
            {
                enumerator.MoveNext();

                for (int i = 0; i < M; i++, enumerator.MoveNext())
                {
                    _source[i] = new double[N];

                    for (int j = 0; j < N; j++)
                    {
                        if (enumerator.Current != null)
                        {
                            _source[i][j] = enumerator.Current[j];
                        }
                    }
                }
            }
        }

        public int M { get; }

        public int N { get; }

        public virtual double this[int i, int j]
        {
            get
            {
                if (i < 1 || i > M) throw new IndexOutOfRangeException(nameof(i));
                if (j < 1 || j > N) throw new IndexOutOfRangeException(nameof(j));

                return _source[--i][--j];
            }
            set
            {
                if (i < 1 || i > M) throw new IndexOutOfRangeException(nameof(i));
                if (j < 1 || j > N) throw new IndexOutOfRangeException(nameof(j));

                _source[--i][--j] = value;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_source, M, N);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix);
        }

        public bool Equals(Matrix matrix)
        {
            return Operation.Equals(this, matrix);
        }

        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            return Calculator.Add(matrixA, matrixB);
        }

        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            return Calculator.Subtract(matrixA, matrixB);
        }

        public static Matrix operator *(Matrix matrixA, double number)
        {
            return Calculator.Multiply(matrixA, number);
        }

        public static Matrix operator *(double number, Matrix matrixA)
        {
            return Calculator.Multiply(matrixA, number);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            return Calculator.Multiply(matrixA, matrixB);
        }

        public static bool operator ==(Matrix matrixA, Matrix matrixB)
        {
            return Operation.Equals(matrixA, matrixB);
        }

        public static bool operator !=(Matrix matrixA, Matrix matrixB)
        {
            return !(matrixA == matrixB);
        }
    }
}

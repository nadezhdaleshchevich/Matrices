using System;
using System.Collections.Generic;
using System.Linq;
using Matrices.Infrastructure.Operations.Extensions;

namespace Matrices.Infrastructure.Core.Models
{
    public abstract class Matrix : IEquatable<Matrix>, ICloneable
    {
        private readonly double[][] _source;

        protected Matrix(int m, int n)
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

        protected Matrix(IEnumerable<double[]> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (source.FirstOrDefault() == null) throw new ArgumentNullException(nameof(source));
            if (source.Any(row => row.Length != source.First().Length)) throw new ArgumentException(nameof(source));

            M = source.Count();
            N = source.First().Length;

            _source = new double[M][];

            using (var enumerator = source.GetEnumerator())
            {
                enumerator.MoveNext();

                for (int i = 0; i < M; i++, enumerator.MoveNext())
                {
                    if (enumerator.Current != null)
                    {
                        _source[i] = new double[N];

                        enumerator.Current.CopyTo(_source[i], 0);
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

        public abstract object Clone();

        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            return Operation.Add(matrixA, matrixB);
        }

        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            return Operation.Subtract(matrixA, matrixB);
        }

        public static Matrix operator *(Matrix matrixA, double number)
        {
            return Operation.Multiply(matrixA, number);
        }

        public static Matrix operator *(double number, Matrix matrixA)
        {
            return Operation.Multiply(matrixA, number);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            return Operation.Multiply(matrixA, matrixB);
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

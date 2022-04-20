using System;
using Matrices.Infrastructure.Operations.Extensions;

namespace Matrices.Infrastructure.Models
{
    public class Matrix
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

        public int M { get; }

        public int N { get; }

        public virtual double this[int m, int n]
        {
            get
            {
                if (m < 1 || m > M) throw new IndexOutOfRangeException(nameof(m));
                if (n < 1 || n > N) throw new IndexOutOfRangeException(nameof(n));

                return _source[--m][--n];
            }
            set
            {
                if (m < 1 || m > M) throw new IndexOutOfRangeException(nameof(m));
                if (n < 1 || n > N) throw new IndexOutOfRangeException(nameof(n));

                _source[--m][--n] = value;
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
            if (matrix == null)
            {
                return false;
            }

            return Operation.Equals(this, matrix);
        }

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
            return !Operation.Equals(matrixA, matrixB);
        }
    }
}

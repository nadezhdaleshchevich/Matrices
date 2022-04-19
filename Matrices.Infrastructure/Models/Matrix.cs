using System;
using Autofac;
using Matrices.Infrastructure.Implementation;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Models
{
    public class Matrix
    {
        private static readonly IAddition Addition;
        private static readonly ISubtraction Subtraction;
        private static readonly IMultiplication Multiplication;

        private readonly double[][] _source;

        static Matrix()
        {
            Addition = Container.Instance.Resolve<IAddition>();
            Subtraction = Container.Instance.Resolve<ISubtraction>();
            Multiplication = Container.Instance.Resolve<IMultiplication>();
        }

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

        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            return Addition.Add(matrixA, matrixB);
        }

        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            return Subtraction.Subtract(matrixA, matrixB);
        }

        public static Matrix operator *(Matrix matrixA, double number)
        {
            return Multiplication.Multiply(matrixA, number);
        }

        public static Matrix operator *(double number, Matrix matrixA)
        {
            return Multiplication.Multiply(matrixA, number);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            return Multiplication.Multiply(matrixA, matrixB);
        }
    }
}

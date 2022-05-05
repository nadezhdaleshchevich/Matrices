using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Infrastructure.Core.Interfaces
{
    internal interface IMatrixFactory
    {
        public Matrix CreateMatrix(int m, int n);
        public Matrix CreateMatrix(IEnumerable<double[]> source);

    }
}

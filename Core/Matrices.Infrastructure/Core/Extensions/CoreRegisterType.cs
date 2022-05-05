using System;
using Matrices.Infrastructure.Core.Interfaces;
using Matrices.Infrastructure.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Infrastructure.Core.Extensions
{
    internal static class CoreRegisterType
    {
        public static void LoadCore(this IServiceCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            collection.AddTransient<IMatrixFactory, MatrixFactory>();
        }
    }
}

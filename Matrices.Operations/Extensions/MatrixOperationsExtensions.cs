using Matrices.Operations.Implementations;
using Matrices.Operations.Interfaces;
using Matrices.Operations.MatrixOperationsValidation.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Operations.Extensions
{
    public static class MatrixOperationsExtensions
    {
        public static void AddMatrixOperations(this IServiceCollection services)
        {
            // TODO move
            services.AddTransient<IMatrixAdditionSubtractionService, MatrixAdditionSubtractionService>();

            services.AddMatrixOperationsValidation();
        }
    }
}

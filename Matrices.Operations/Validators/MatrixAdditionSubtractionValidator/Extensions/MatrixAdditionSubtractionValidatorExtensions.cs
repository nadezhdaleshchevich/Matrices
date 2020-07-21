using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Implementations;
using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Extensions
{
    internal static class MatrixAdditionSubtractionValidatorExtensions
    {
        public static void AddMatrixAdditionSubtractionValidatorValidator(this IServiceCollection services)
        {
            services.AddTransient<IMatrixSizeValidationService, MatrixSizeValidationService>();
            services.AddTransient<IMatrixAdditionSubtractionValidatorSaga, MatrixAdditionSubtractionValidatorSaga>();
        }
    }
}

using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Operations.Validators.Extensions
{
    internal static class ValidatorExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddMatrixAdditionSubtractionValidatorValidator();
        }
    }
}

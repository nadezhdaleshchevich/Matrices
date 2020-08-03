using Matrices.Infrastructure.ChainOfHandlers.Interfaces;
using Matrices.Infrastructure.Core.Models;

namespace Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models
{
    internal class MatrixAdditionSubtractionValidationContext : IChainContext
    {
        public Matrix First { get; set; }
        public Matrix Second { get; set; }
    }
}

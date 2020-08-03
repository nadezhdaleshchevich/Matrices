using Matrices.Infrastructure.ChainOfHandlers.Interfaces;

namespace Matrices.Operations.MatrixOperationsValidation.MatrixAdditionSubtractionValidation.Models
{
    internal class MatrixAdditionSubtractionValidationResult : IChainResult
    {
        public bool IsValid { get; set; }
        public string Error { get; set; }
    }
}

using System;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Saga.Interfaces;
using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Commands;
using Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Interfaces;

namespace Matrices.Operations.Validators.MatrixAdditionSubtractionValidator.Implementations
{
    internal class MatrixAdditionSubtractionValidatorSaga : IMatrixAdditionSubtractionValidatorSaga,
        ISagaCommandHandler<IsMatricesExistCommand>,
        ISagaCommandHandler<IsMatrixSizeEqualCommand>
    {
        private readonly ISagaRunStrategy<MatrixAdditionSubtractionValidatorSagaContext> _sagaRunStrategy;
        private readonly IMatrixSizeValidationService _matrixSizeValidationService;

        public MatrixAdditionSubtractionValidatorSaga(
            ISagaRunStrategy<MatrixAdditionSubtractionValidatorSagaContext> sagaRunStrategy,
            IMatrixSizeValidationService matrixSizeValidationService)
        {
            _sagaRunStrategy = sagaRunStrategy;
            _matrixSizeValidationService = matrixSizeValidationService;

            RegisterHandles();
        }

        internal Matrix First { get; set; }
        internal Matrix Second { get; set; }
        private bool IsValid { get; set; }
        private string ErrorMessage { get; set; }

        public bool Handle(IsMatricesExistCommand command)
        {
            IsValid = true;

            if (First == null)
            {
                IsValid = false;
                ErrorMessage = $"The {nameof(First)} can not be null.";
            }

            if (Second == null)
            {
                IsValid = false;
                ErrorMessage = $"The {nameof(Second)} can not be null.";
            }

            return IsValid;
        }

        public bool Handle(IsMatrixSizeEqualCommand command)
        {
            var result = _matrixSizeValidationService.IsMatrixSizeValid(First, Second);

            IsValid = result.IsValid;

            if (!IsValid)
            {
                ErrorMessage = result.ValidationMessage;
            }

            return IsValid;
        }

        public (bool IsValid, string ValidationMessage) IsMatricesValid(MatrixAdditionSubtractionValidatorSagaContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            First = context.First;
            Second = context.Second;

            _sagaRunStrategy.Run(context);

            return (IsValid, ErrorMessage);
        }

        private void RegisterHandles()
        {
            _sagaRunStrategy.AddCommandHandler(context => Handle(new IsMatricesExistCommand()));
            _sagaRunStrategy.AddCommandHandler(context => Handle(new IsMatrixSizeEqualCommand()));
        }
    }
}

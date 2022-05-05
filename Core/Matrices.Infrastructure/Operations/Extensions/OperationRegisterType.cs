using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Core.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Operations.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Infrastructure.Operations.Extensions
{
    internal static class OperationRegisterType
    {
        public static void LoadOperation(this IServiceCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            collection.AddTransient<IAddition, Addition>();
            collection.AddTransient<ISubtraction, Subtraction>();
            collection.AddTransient<IMultiplication, Multiplication> ();

            collection.AddTransient<IAlgebraicAddition, AlgebraicAddition> ();

            collection.AddTransient<IDeterminantCalculator, DeterminantCalculator> ();
            collection.AddTransient<IDeterminantFor1X1Calculator, DeterminantFor1X1Calculator> ();
            collection.AddTransient<IDeterminantFor2X2Calculator, DeterminantFor2X2Calculator> ();
            collection.AddTransient<IDeterminantFor3X3Calculator, DeterminantFor3X3Calculator> ();

            collection.AddTransient<ITransposition, Transposition>();

            collection.AddTransient<IEqualityComparer<Matrix>, MatrixEqualityComparer> ();
        }
    }
}

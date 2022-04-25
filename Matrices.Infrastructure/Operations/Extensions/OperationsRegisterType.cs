using System;
using System.Collections.Generic;
using Autofac;
using Matrices.Infrastructure.Models;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure.Operations.Extensions
{
    internal static class OperationsRegisterType
    {
        public static void LoadOperations(this ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.RegisterType<Addition>().As<IAddition>().InstancePerLifetimeScope();
            builder.RegisterType<Subtraction>().As<ISubtraction>().InstancePerLifetimeScope();
            builder.RegisterType<Multiplication>().As<IMultiplication>().InstancePerLifetimeScope();

            builder.RegisterType<AlgebraicAddition>().As<IAlgebraicAddition>().InstancePerLifetimeScope();

            builder.RegisterType<DeterminantCalculator>().As<IDeterminantCalculator>().InstancePerLifetimeScope();
            builder.RegisterType<DeterminantFor1X1Calculator>().As<IDeterminantFor1X1Calculator>().InstancePerLifetimeScope();
            builder.RegisterType<DeterminantFor2X2Calculator>().As<IDeterminantFor2X2Calculator>().InstancePerLifetimeScope();
            builder.RegisterType<DeterminantFor3X3Calculator>().As<IDeterminantFor3X3Calculator>().InstancePerLifetimeScope();
            
            builder.RegisterType<MatrixEqualityComparer>().As<IEqualityComparer<Matrix>>().InstancePerLifetimeScope();
            
            builder.RegisterType<Transposition>().As<ITransposition>().InstancePerLifetimeScope();
        }
    }
}

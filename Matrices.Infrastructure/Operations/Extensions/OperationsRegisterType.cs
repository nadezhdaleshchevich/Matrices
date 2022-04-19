using System;
using Autofac;
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
            builder.RegisterType<AlgebraicAddition>().As<IAlgebraicAddition>().InstancePerLifetimeScope();
            builder.RegisterType<Determinant>().As<IDeterminant>().InstancePerLifetimeScope();
            builder.RegisterType<Multiplication>().As<IMultiplication>().InstancePerLifetimeScope();
            builder.RegisterType<Subtraction>().As<ISubtraction>().InstancePerLifetimeScope();
            builder.RegisterType<Transposition>().As<ITransposition>().InstancePerLifetimeScope();
        }
    }
}

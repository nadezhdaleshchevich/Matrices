using Autofac;
using Matrices.Infrastructure.Operations.Implementation;
using Matrices.Infrastructure.Operations.Interfaces;

namespace Matrices.Infrastructure
{
    internal static class Container
    {
        private static IContainer _container;

        public static IContainer Instance
        {
            get
            {
                if (_container == null)
                {
                    Initialize();
                }

                return _container;
            }
        }

        private static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.Load();
            _container = builder.Build();
        }

        private static void Load(this ContainerBuilder builder)
        {
            builder.RegisterType<Addition>().As<IAddition>().InstancePerLifetimeScope();
            builder.RegisterType<Subtraction>().As<ISubtraction>().InstancePerLifetimeScope();
            builder.RegisterType<Multiplication>().As<IMultiplication>().InstancePerLifetimeScope();
            builder.RegisterType<Transposition>().As<ITransposition>().InstancePerLifetimeScope();
        }
    }
}

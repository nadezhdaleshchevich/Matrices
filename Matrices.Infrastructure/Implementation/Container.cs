using Autofac;
using Matrices.Infrastructure.Operations.Extensions;

namespace Matrices.Infrastructure.Implementation
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
            builder.LoadOperations();
        }
    }
}

using System;
using Matrices.Infrastructure.Core.Extensions;
using Matrices.Infrastructure.Operations.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Infrastructure.Core.Services
{
    internal static class Container
    {
        private static IServiceProvider _serviceProvider = null;

        public static IServiceProvider Instance
        {
            get
            {
                if (_serviceProvider == null)
                {
                    var services = new ServiceCollection();
                    services.LoadTypes();

                    _serviceProvider = services.BuildServiceProvider();
                }

                return _serviceProvider;
            }
                
            set => _serviceProvider = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static T GetService<T>()
        {
            return Instance.GetService<T>();
        }

        private static void LoadTypes(this IServiceCollection collection)
        {
            collection.LoadCore();
            collection.LoadOperation();
        }
    }
}

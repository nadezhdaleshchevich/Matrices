using System;
using System.Collections.Generic;
using System.Linq;
using Matrices.Infrastructure.ChainOfHandlers.Implementations;
using Matrices.Infrastructure.ChainOfHandlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Infrastructure.ChainOfHandlers.Extensions
{
    public static class ChainOfHandlersExtensions
    {
        public static void AddChainOfHandlers<TChainContext, TChainResult>(
            this IServiceCollection services,
            IEnumerable<Type> handlers)
            where TChainContext : class, IChainContext
            where TChainResult : class, IChainResult
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (handlers == null || handlers.Any(handler => handler == null)) throw new ArgumentNullException(nameof(handlers));

            services.AddChainOfHandlers<
                IChainService<TChainContext, TChainResult>,
                ChainService<TChainContext, TChainResult>,
                IChainHandler<TChainContext, TChainResult>,
                TChainContext,
                TChainResult>(handlers);
        }

        private static void AddChainOfHandlers<TInterface, TImplementation, TChainHandler, TChainContext, TChainResult>(
            this IServiceCollection services,
            IEnumerable<Type> handlers)
            where TInterface : class, IChainService<TChainContext, TChainResult>
            where TImplementation : class, TInterface
            where TChainHandler : class, IChainHandler<TChainContext, TChainResult>
            where TChainContext : class, IChainContext
            where TChainResult : class, IChainResult
        {
            services.AddTransient<TInterface, TImplementation>();

            services.AddTransient<IEnumerable<TChainHandler>>(provider =>
                handlers.Select(type => (TChainHandler) provider.GetService(type)).ToList());

            services.AddHandlers(handlers);
        }

        private static void AddHandlers(
            this IServiceCollection services,
            IEnumerable<Type> handlers)
        {
            foreach (var type in handlers)
            {
                services.AddTransient(type);
            }
        }
    }
}

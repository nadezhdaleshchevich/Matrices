using Matrices.Infrastructure.Saga.Implementations;
using Matrices.Infrastructure.Saga.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.Infrastructure.Saga.Extensions
{
    public static class SagaExtensions
    {
        public static void AddSaga(this IServiceCollection services)
        {
            services.AddTransient(typeof(ISagaRunStrategy<>), typeof(SagaRunWhileTrueStrategy<>));
            services.AddTransient(typeof(ISyncSagaRunStrategy<>), typeof(SyncSagaRunWhileTrueStrategy<>));
        }
    }
}

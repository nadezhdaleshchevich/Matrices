using System;
using System.Threading.Tasks;

namespace Matrices.Infrastructure.Saga.Interfaces
{
    public interface ISagaRunStrategy<TSagaContext>
    {
        Task RunAsync(TSagaContext context);
        void AddCommandHandler(Func<TSagaContext, Task<bool>> handler);
    }
}

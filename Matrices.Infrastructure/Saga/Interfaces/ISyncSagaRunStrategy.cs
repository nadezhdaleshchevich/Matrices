using System;

namespace Matrices.Infrastructure.Saga.Interfaces
{
    public interface ISyncSagaRunStrategy<TSagaContext>
    {
        void Run(TSagaContext context);
        void AddCommandHandler(Func<TSagaContext, bool> handler);
    }
}

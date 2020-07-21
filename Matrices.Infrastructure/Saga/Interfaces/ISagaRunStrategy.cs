using System;

namespace Matrices.Infrastructure.Saga.Interfaces
{
    public interface ISagaRunStrategy<TSagaContext>
    {
        void Run(TSagaContext context);
        void AddCommandHandler(Func<TSagaContext, bool> handler);
    }
}

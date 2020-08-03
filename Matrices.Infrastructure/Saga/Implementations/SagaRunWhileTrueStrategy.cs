using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrices.Infrastructure.Saga.Interfaces;

namespace Matrices.Infrastructure.Saga.Implementations
{
    internal class SagaRunWhileTrueStrategy<TSagaContext> : ISagaRunStrategy<TSagaContext>
    {
        private readonly List<Func<TSagaContext, Task<bool>>> _handlers;

        public SagaRunWhileTrueStrategy()
        {
            _handlers = new List<Func<TSagaContext, Task<bool>>>();
        }

        public async Task RunAsync(TSagaContext context)
        {
            foreach (var handler in _handlers)
            {
                var result = await handler.Invoke(context);

                if (!result) break;
            }
        }

        public void AddCommandHandler(Func<TSagaContext, Task<bool>> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            _handlers.Add(handler);
        }
    }
}
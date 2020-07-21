using System;
using System.Collections.Generic;
using Matrices.Infrastructure.Saga.Interfaces;

namespace Matrices.Infrastructure.Saga.Implementations
{
    internal class SagaRunWhileTrueStrategy<TSagaContext> : ISagaRunStrategy<TSagaContext>
    {
        private readonly List<Func<TSagaContext, bool>> _handlers;

        public SagaRunWhileTrueStrategy()
        {
            _handlers = new List<Func<TSagaContext, bool>>();
        }

        public void Run(TSagaContext context)
        {
            foreach (var handler in _handlers)
            {
                var result = handler.Invoke(context);

                if (!result) break;
            }
        }

        public void AddCommandHandler(Func<TSagaContext, bool> handler)
        {
            _handlers.Add(handler);
        }
    }
}
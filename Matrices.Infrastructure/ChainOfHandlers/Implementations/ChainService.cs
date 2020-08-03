using System.Collections.Generic;
using Matrices.Infrastructure.ChainOfHandlers.Interfaces;

namespace Matrices.Infrastructure.ChainOfHandlers.Implementations
{
    internal class ChainService<TChainContext, TChainResult> : IChainService<TChainContext, TChainResult>
        where TChainContext : class, IChainContext
        where TChainResult : class, IChainResult
    {
        private readonly List<IChainHandler<TChainContext, TChainResult>> _handlers;

        public ChainService(List<IChainHandler<TChainContext, TChainResult>> handlers)
        {
            _handlers = handlers;
        }

        public bool Run(TChainContext context, TChainResult result)
        {
            foreach (var handler in _handlers)
            {
                var handleResult = handler.Handle(context, result);

                if (!handleResult) return false;
            }

            return true;
        }
    }
}

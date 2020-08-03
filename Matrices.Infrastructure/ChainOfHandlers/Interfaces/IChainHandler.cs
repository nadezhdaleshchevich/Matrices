namespace Matrices.Infrastructure.ChainOfHandlers.Interfaces
{
    public interface IChainHandler<in TChainContext, in TChainResult>
        where TChainContext : class, IChainContext
        where TChainResult : class, IChainResult
    {
        bool Handle(TChainContext context, TChainResult result);
    }
}

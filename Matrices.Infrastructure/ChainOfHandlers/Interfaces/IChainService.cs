namespace Matrices.Infrastructure.ChainOfHandlers.Interfaces
{
    public interface IChainService<in TChainContext, in TChainResult>
        where TChainContext : class, IChainContext
        where TChainResult : class, IChainResult
    {
        bool Run(TChainContext context, TChainResult result);
    }
}

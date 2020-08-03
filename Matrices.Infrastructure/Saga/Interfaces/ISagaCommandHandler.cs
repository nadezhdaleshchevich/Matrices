using System.Threading.Tasks;

namespace Matrices.Infrastructure.Saga.Interfaces
{
    public interface ISagaCommandHandler<in TSagaCommand>
    {
        Task<bool> HandleAsync(TSagaCommand command);
    }
}

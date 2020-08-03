namespace Matrices.Infrastructure.Saga.Interfaces
{
    public interface ISyncSagaCommandHandler<in TSagaCommand>
    {
        bool Handle(TSagaCommand command);
    }
}

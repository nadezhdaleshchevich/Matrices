namespace Matrices.Infrastructure.Saga.Interfaces
{
    public interface ISagaCommandHandler<in TSagaCommand>
    {
        bool Handle(TSagaCommand command);
    }
}

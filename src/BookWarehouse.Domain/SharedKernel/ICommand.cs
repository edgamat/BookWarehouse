using CSharpFunctionalExtensions;

namespace BookWarehouse.Domain.SharedKernel
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}

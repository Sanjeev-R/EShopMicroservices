using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQueryHandler<in TCommand>
        : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }
    public interface IQueryHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}

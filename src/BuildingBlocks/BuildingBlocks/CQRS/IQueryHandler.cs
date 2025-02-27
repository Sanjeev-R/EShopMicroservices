﻿using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQueryHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}

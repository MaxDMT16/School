using System;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Exceptions.Attributes;

namespace SchoolSystem.Abstractions.Exceptions.Queries
{
    public class EntityNotFoundException<TEntity, TQuery, TResult> : QueryException<TQuery, TResult>
        where TResult : IQueryResult
        where TQuery : IQuery<TResult>
    {
        public EntityNotFoundException(TQuery query) : base(query)
        {
        }

        [Log] public Type EntityType => typeof(TEntity);
    }
}
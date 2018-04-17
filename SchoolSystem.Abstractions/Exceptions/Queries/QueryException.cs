using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Queries
{
    public abstract class QueryException<TQuery, TQueryResult> : SchoolSystemException
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
        [Log] public TQuery Query { get; }

        protected QueryException(TQuery query)
        {
            Query = query;
        }
    }
}
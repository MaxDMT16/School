using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Exceptions.Queries
{
    public class QueryHandlerNotFoundException<TQuery, TQueryResult> : QueryException<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
        public QueryHandlerNotFoundException(TQuery query) : base(query)
        {
        }
    }
}
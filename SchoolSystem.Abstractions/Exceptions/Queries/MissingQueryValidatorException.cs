using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Exceptions.Queries
{
    public class MissingQueryValidatorException<TQuery, TQueryResult> : QueryException<TQuery, TQueryResult>
        where TQueryResult : IQueryResult
        where TQuery : IQuery<TQueryResult>
    {
        public MissingQueryValidatorException(TQuery query) : base(query)
        {
        }
    }
}
using System.Threading.Tasks;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.CQRS.Handlers
{
    public interface IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
        Task<TQueryResult> Execute(TQuery query);
    }
}
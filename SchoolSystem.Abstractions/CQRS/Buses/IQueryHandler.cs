using System.Threading.Tasks;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.CQRS.Buses
{
    public interface IQueryHandler
    {
        Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery<TQueryResult>
            where TQueryResult : IQueryResult;
    }
}
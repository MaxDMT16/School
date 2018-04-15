using System.Threading.Tasks;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.CQRS.Handlers;
using SchoolSystem.Database.Context;

namespace SchoolSystem.Database.Handlers
{
    public abstract class QueryHandlerBase<TQuery, TQueryResult> : IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
        protected readonly ISchoolSystemDbContext DbContext;

        protected QueryHandlerBase(ISchoolSystemDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TQueryResult> Execute(TQuery query);
    }
}
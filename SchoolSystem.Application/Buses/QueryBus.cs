using System.Threading.Tasks;
using Autofac;
using FluentValidation;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.CQRS.Handlers;
using SchoolSystem.Abstractions.Exceptions.Base;
using SchoolSystem.Abstractions.Exceptions.Queries;

namespace SchoolSystem.Application.Buses
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public QueryBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>
            where TQueryResult : IQueryResult
        {
            var queryHandler = ResolveHandler<TQuery, TQueryResult>(query);

            await Validate<TQuery, TQueryResult>(query);

            var queryResult = await queryHandler.Execute(query);

            return queryResult;
        }

        private IQueryHandler<TQuery, TQueryResult> ResolveHandler<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery<TQueryResult>
            where TQueryResult : IQueryResult
        {
            var queryHandler = _lifetimeScope.ResolveOptional<IQueryHandler<TQuery, TQueryResult>>();

            if (queryHandler == null)
            {
                throw new QueryHandlerNotFoundException<TQuery, TQueryResult>(query);
            }

            return queryHandler;
        }

        private async Task Validate<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery<TQueryResult>
            where TQueryResult : IQueryResult
        {
            var validator = _lifetimeScope.ResolveOptional<IValidator<TQuery>>();

            if (validator == null)
            {
                throw new MissingQueryValidatorException<TQuery, TQueryResult>(query);
            }

            var validationResult = await validator.ValidateAsync(query);

            if (validationResult == null)
            {
                throw new CorruptedValidatorException<IValidator<TQuery>, TQuery>(validator, query);
            }

            if (!validationResult.IsValid)
            {
                throw new Abstractions.Exceptions.Base.ValidationException(query, validationResult.Errors);
            }
        }
    }
}
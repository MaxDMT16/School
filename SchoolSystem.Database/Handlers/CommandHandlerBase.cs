using System.Threading.Tasks;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.CQRS.Handlers;
using SchoolSystem.Database.Context;

namespace SchoolSystem.Database.Handlers
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected readonly ISchoolSystemDbContext DbContext;

        public CommandHandlerBase(ISchoolSystemDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task Execute(TCommand command);
    }
}
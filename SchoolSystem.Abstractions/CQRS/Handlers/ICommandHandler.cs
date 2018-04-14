using System.Threading.Tasks;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.CQRS.Handlers
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}
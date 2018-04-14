using System.Threading.Tasks;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.CQRS.Buses
{
    public interface ICommandBus
    {
        Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
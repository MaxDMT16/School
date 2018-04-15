using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Groups
{
    public class CreateGroupCommand : ICommand
    {
        public string Name { get; set; }
    }
}
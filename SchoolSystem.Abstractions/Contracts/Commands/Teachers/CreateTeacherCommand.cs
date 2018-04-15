using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Teachers
{
    public class CreateTeacherCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
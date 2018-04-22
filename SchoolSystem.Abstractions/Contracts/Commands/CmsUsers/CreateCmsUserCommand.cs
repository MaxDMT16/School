using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Commands.CmsUsers
{
    public class CreateCmsUserCommand : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public ScopeFlag Scope { get; set; }
    }
}
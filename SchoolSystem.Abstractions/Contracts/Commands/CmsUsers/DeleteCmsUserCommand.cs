using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.CmsUsers
{
    public class DeleteCmsUserCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
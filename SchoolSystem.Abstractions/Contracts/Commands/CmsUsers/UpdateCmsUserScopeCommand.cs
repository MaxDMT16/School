using System;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Commands.CmsUsers
{
    public class UpdateCmsUserScopeCommand : ICommand
    {
        public Guid Id { get; set; }
        public Scope Scope { get; set; }
    }
}
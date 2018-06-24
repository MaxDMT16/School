using System;
using SchoolSystem.Abstractions.Authorization.Scopes;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Queries.CmsUsers
{
    public class CmsUserIdAndScopeResponse : IQueryResult
    {
        public Guid Id { get; set; }
        public Scope Scope { get; set; }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Abstractions.Exceptions.Authorization;
using SchoolSystem.Domain.Authorization.Services;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class OAuthAttribute : ActionFilterAttribute
    {
        public OAuthAttribute(Scope scope)
        {
            Scope = scope;
        }

        public Scope Scope { get; }
    }
}
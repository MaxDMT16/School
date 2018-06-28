using System;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolSystem.Abstractions.Enums;

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
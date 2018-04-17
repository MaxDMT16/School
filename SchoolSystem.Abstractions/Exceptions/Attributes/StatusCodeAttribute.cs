using System;
using System.Net;

namespace SchoolSystem.Abstractions.Exceptions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StatusCodeAttribute : Attribute
    {
        public StatusCodeAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
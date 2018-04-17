using System.Collections.Generic;
using FluentValidation.Results;
using SchoolSystem.Abstractions.Exceptions.Attributes;

namespace SchoolSystem.Abstractions.Exceptions.Base
{
    public class ValidationException : SchoolSystemException
    {
        public ValidationException(object invalidObject, IEnumerable<ValidationFailure> failures)
        {
            InvalidObject = invalidObject;
            Failures = failures;
        }

        [Log, Response] public object InvalidObject { get; }

        [Log, Response] public IEnumerable<ValidationFailure> Failures { get; }
    }
}
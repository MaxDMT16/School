using System;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class ControllerTypeMissmatchException : SchoolSystemException
    {
        public ControllerTypeMissmatchException(Type controllerType)
        {
            ControllerType = controllerType;
        }

        [Log]
        public Type ControllerType { get; }
    }
}
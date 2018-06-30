using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Pupils
{
    public class UpdatePupilByRegistrationCodeCommand : ICommand
    {
        public Guid RegistrationCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
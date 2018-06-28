using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Teachers
{
    public class UpdateTeacherByRegistrationCodeCommand : ICommand
    {
        public Guid RegistrationCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
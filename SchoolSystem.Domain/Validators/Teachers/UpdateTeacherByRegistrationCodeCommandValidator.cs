using FluentValidation;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;

namespace SchoolSystem.Domain.Validators.Teachers
{
    public class UpdateTeacherByRegistrationCodeCommandValidator : AbstractValidator<UpdateTeacherByRegistrationCodeCommand>
    {
        public UpdateTeacherByRegistrationCodeCommandValidator()
        {
            RuleFor(command => command.RegistrationCode).NotEmpty();
            RuleFor(command => command.Email).EmailAddress();
            RuleFor(command => command.Password).NotEmpty();
        }
    }
}
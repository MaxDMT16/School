using FluentValidation;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;

namespace SchoolSystem.Domain.Validators.Pupils
{
    public class UpdatePupilCredentialsByRegistrationCodeCommandValidator : 
        AbstractValidator<UpdatePupilByRegistrationCodeCommand>
    {
        public UpdatePupilCredentialsByRegistrationCodeCommandValidator()
        {
            RuleFor(command => command.RegistrationCode).NotEmpty();
            RuleFor(command => command.Email).EmailAddress();
            RuleFor(command => command.Password).NotEmpty();
        }
    }
}
using FluentValidation;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;

namespace SchoolSystem.Domain.Validators.Pupils
{
    public class CreatePupilCommandValidator : AbstractValidator<CreatePupilCommand>
    {
        public CreatePupilCommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
            RuleFor(command => command.GroupId).NotEmpty();
        }
    }
}
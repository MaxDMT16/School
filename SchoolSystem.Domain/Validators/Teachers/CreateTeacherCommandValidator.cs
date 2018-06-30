using FluentValidation;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;

namespace SchoolSystem.Domain.Validators.Teachers
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
        }
    }
}
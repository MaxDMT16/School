using FluentValidation;
using SchoolSystem.Abstractions.Exceptions.Attributes;

namespace SchoolSystem.Abstractions.Exceptions.Base
{
    public class CorruptedValidatorException<TValidator, TItem> : SchoolSystemException
        where TValidator : IValidator<TItem>
    {
        public CorruptedValidatorException(TValidator corruptedValidator, TItem item)
        {
            CorruptedValidator = corruptedValidator;
            Item = item;
        }

        [Log] public TValidator CorruptedValidator { get; }
        [Log] public TItem Item { get; }
    }
}
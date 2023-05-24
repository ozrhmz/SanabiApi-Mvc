using App.Core.DTOs;
using FluentValidation;

namespace App.Service.Validations
{
    public class PaymentTypeValidator : AbstractValidator<PaymentTypeDto>
    {
        public PaymentTypeValidator()
        {
            RuleFor(x => x.TypeName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(100).WithMessage("{PropertyName} is max length 100 characters");
        }
    }
}

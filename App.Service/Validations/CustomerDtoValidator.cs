using App.Core.DTOs;
using FluentValidation;

namespace App.Service.Validations
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 50 characters");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 50 characters");
            RuleFor(x => x.Mail).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(200).WithMessage("{PropertyName} is max length 200 characters");
            RuleFor(x => x.NumberPhone).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(11).WithMessage("{PropertyName} is max length 11 characters");
        }
    }
}

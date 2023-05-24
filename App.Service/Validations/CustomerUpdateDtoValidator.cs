using App.Core.DTOs;
using FluentValidation;

namespace App.Service.Validations
{
    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 50 characters");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 50 characters");
            RuleFor(x => x.Mail).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(200).WithMessage("{PropertyName} is max length 200 characters");
            RuleFor(x => x.NumberPhone).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(11).WithMessage("{PropertyName} is max length 11 characters");
        }
    }
}

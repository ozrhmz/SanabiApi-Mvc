using App.Core.DTOs;
using FluentValidation;

namespace App.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(100).WithMessage("{PropertyName} is max length 100 characters");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(500).WithMessage("{PropertyName} is max length 500 characters");
            RuleFor(x => x.Image).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Price).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater");
            RuleFor(x => x.Stock).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater");
            RuleFor(x => x.CreateDate).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 500 characters");
        }
    }
}

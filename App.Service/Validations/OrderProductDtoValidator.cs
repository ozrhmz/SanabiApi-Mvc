using App.Core.DTOs;
using FluentValidation;

namespace App.Service.Validations
{
    public class OrderProductDtoValidator : AbstractValidator<OrderProductDto>
    {
        public OrderProductDtoValidator()
        {
            RuleFor(x => x.product.Id).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}

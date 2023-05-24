using App.Core.DTOs;
using FluentValidation;

namespace App.Service.Validations
{
    public class AdressUpdateDtoValidator : AbstractValidator<AdressUpdateDto>
    {
        public AdressUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MaximumLength(100).WithMessage("{PropertyName} is max length 100 characters");
            RuleFor(x => x.Province).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MaximumLength(30).WithMessage("{PropertyName} is max length 30 characters");
            RuleFor(x => x.Districte).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MaximumLength(30).WithMessage("{PropertyName} is max length 30 characters");
            RuleFor(x => x.Neighbourhood).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 50 characters");
            RuleFor(x => x.Street).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").MaximumLength(50).WithMessage("{PropertyName} is max length 50 characters");
            RuleFor(x => x.Building_No).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Post_Code).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(10000, int.MaxValue).WithMessage("{PropertyName} must be greater 10000");
            RuleFor(x => x.Apartment_Number).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}

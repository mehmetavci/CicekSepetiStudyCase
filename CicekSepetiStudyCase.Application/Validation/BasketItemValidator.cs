using CicekSepetiStudyCase.Manager.Dtos;
using FluentValidation;

namespace CicekSepetiStudyCase.Manager.Validation
{
    public class BasketItemValidator : AbstractValidator<BasketItemDto>
    {
        public BasketItemValidator()
        {
            RuleFor(x => x.ProductId).NotNull().WithMessage("ProductId field is required");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Quantity field is required")
                .GreaterThan(0).WithMessage("Quantity should be greater than 0");
        }
    }
}

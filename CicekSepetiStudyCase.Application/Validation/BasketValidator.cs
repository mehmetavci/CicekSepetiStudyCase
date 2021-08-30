using CicekSepetiStudyCase.Manager.Dtos;
using FluentValidation;

namespace CicekSepetiStudyCase.Manager.Validation
{
    public class BasketValidator : AbstractValidator<BasketDto>
    {
        public BasketValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required");
            RuleFor(x => x.Item).SetValidator(new BasketItemValidator());
        }
    }
}

using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
                .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

        }
    }
}
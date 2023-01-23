using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Orders.Send
{
    public class SendOrderCommandValidator : AbstractValidator<SendOrderCommand>
    {
        public SendOrderCommandValidator()
        {
            RuleFor(r => r.TrackingCode)
                .NotEmpty().WithMessage(ValidationMessages.required("کد رهگیری"))
                .NotNull();
        }
    }
}

using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(f => f.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(f => f.Family)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(f => f.City)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(f => f.Shire)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PostalAddress)
              .NotNull()
              .NotEmpty()
              .WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PostalCode)
             .NotNull()
             .NotEmpty()
             .WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PhoneNumber)
              .NotNull()
              .NotEmpty()
              .WithMessage(ValidationMessages.required("شماره"))
              .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است")
              .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است");

          
    }
}

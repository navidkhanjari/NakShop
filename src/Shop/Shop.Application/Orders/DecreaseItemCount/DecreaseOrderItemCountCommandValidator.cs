using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommandValidator : AbstractValidator<DecreaseOrderItemCountCommand>
    {
        public DecreaseOrderItemCountCommandValidator()
        {

        }
    }
}

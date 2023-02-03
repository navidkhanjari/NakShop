using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.EditAddress
{
    internal class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
    {
        private readonly IUserRepository _repository;

        public EditUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
                request.PhoneNumber, request.Name, request.Family);

            user.EditAddress( request.Id, address);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}

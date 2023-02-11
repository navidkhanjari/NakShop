using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.Register
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly UserDomainService _domainService;

        public RegisterUserCommandHandler(IUserRepository repository, UserDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.PhoneNumber.Value, request.Password, _domainService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

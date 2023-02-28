using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.Register
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;

        public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var IsExist = _repository.Exists(t=> t.PhoneNumber == request.PhoneNumber.Value);
            if (IsExist == true)
                return OperationResult.Error("کاربر از قبل در سیستم موجود می باشد");

            var user = User.RegisterUser(request.PhoneNumber.Value, request.Password, _domainService);
          
            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

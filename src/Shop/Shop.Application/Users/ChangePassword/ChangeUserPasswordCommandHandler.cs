using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Users.ChangePassword
{
    internal class ChangeUserPasswordCommandHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);

            if (user == null)
                return OperationResult.NotFound("کاربری یافت نشد");

            var currentPasswordHash = PasswordHelper.EncodePasswordMd5(request.CurrentPassword);

            if (user.Password != currentPasswordHash)
                return OperationResult.Error("کلمه عبور فعلی نامعتبر است");

            var newPassworHash = PasswordHelper.EncodePasswordMd5(request.NewPassword);
            user.ChangePassword(newPassworHash);

            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}

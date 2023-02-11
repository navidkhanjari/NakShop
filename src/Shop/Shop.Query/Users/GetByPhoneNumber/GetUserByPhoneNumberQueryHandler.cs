using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Users.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetByPhoneNumber
{
    public class GetUserByPhoneNumberQueryHandler : IBaseQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
    {
        private readonly ShopContext _context;

        public GetUserByPhoneNumberQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber, cancellationToken);

            if (user == null)
                return null;


            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}

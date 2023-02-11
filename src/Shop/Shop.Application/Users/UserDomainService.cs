using Shop.Domain.UserAgg.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        public bool IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}

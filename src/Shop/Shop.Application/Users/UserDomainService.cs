using Shop.Domain.UserAgg.Repository;
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
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailExist(string email)
        {
            return _repository.Exists(f => f.Email == email);
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            return _repository.Exists(f => f.PhoneNumber == phoneNumber);
        }
    }
}

using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User:AggregateRoot
    {
        private User()
        {

        }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Avatar { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }

        public User(string name, string family, string phoneNumber, string avatar
            , string email, Gender gender,string password, IUserDomainService domainService)
        {
            Guard(phoneNumber, domainService);
            if (!string.IsNullOrWhiteSpace(email))
                EmailGuard(email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;

            Gender = gender;
            if (string.IsNullOrWhiteSpace(avatar))
                Avatar = "avatar.png";
            else
                Avatar = avatar;
            Roles = new List<UserRole>();
        }
        
        public void Edit(string name, string family, string phoneNumber
            , string email, Gender gender, IUserDomainService domainService)
        {
            Guard(phoneNumber, domainService);
            if (!string.IsNullOrWhiteSpace(email))
                EmailGuard(email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;


            Email = email;
            Gender = gender;
      
        }
        public static User RegisterUser(string phoneNumber, string password, IUserDomainService domainService)
        {
            return new User("", "", phoneNumber,"","", Gender.None, password, domainService);
        }
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            if (Addresses.Count == 0)
                address.SetActive();
            Addresses.Add(address);
        }

        public void SetActiveAddress(Guid addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not found");

            Addresses.ForEach(f => f.ActiveAddress = false);
            oldAddress.SetActive();
        }

        public void DeleteAddress(Guid addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not found");

            Addresses.Remove(oldAddress);
        }

        public void EditAddress(Guid addressId, UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not found");

            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void AddWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }
        public void FinallyWallet(Guid walletId, string? refCode)
        {
            var wallet = Wallets.FirstOrDefault(f => f.Id == walletId);
            if (wallet == null || wallet.IsFinally)
                return;

            if (string.IsNullOrWhiteSpace(refCode))
                wallet.Finally();
            else
                wallet.Finally(refCode);

        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void SetAvatar(string imageName)
        {
            if (!string.IsNullOrWhiteSpace(imageName))
                Avatar = imageName;
        }

        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));
            Password = newPassword;
        }


        private void Guard(string phoneNumber,IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
            if (phoneNumber != PhoneNumber)
                if (domainService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

        }
        private void EmailGuard(string email, IUserDomainService domainService)
        {
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }

    }
}

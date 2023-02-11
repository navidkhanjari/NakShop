﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        private UserAddress()
        {

        }
        public Guid UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string PostalAddress { get; private set; }
        public bool ActiveAddress { get; internal set; }

        public UserAddress(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string name, string family )
        {
            Guard(shire, city, postalCode, postalAddress,
            phoneNumber, name, family );

            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;

            ActiveAddress = false;
        }

        public void Edit(string shire, string city, string postalCode, string postalAddress,
     PhoneNumber phoneNumber, string name, string family)
        {
            Guard(shire, city, postalCode, postalAddress,
                 phoneNumber, name, family);

            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;

        }

        public void SetActive()
        {
            ActiveAddress = true;
        }
        private void Guard(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string name, string family)
        {

            if (phoneNumber == null)
                throw new NullOrEmptyDomainDataException();

            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));

        }
    }
}

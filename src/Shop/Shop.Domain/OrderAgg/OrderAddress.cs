using Common.Domain;
using System;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress:BaseEntity
    {
        public OrderAddress(string shire, string city, string postalCode, string postalAddress,
              string phoneNumber, string name, string family)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;    
        }
        public Guid OrderId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public Order Order { get; set; }
    }
}

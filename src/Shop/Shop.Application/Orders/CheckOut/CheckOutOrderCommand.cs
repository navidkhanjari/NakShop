﻿using Common.Application;
using Shop.Domain.OrderAgg.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommand:IBaseCommand
    {
        public CheckOutOrderCommand(Guid userId, string shire, string city,
            string postalCode, string postalAddress, string phoneNumber, string name,
            string family, OrderDeliveryInfo deliveryInfo)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            DeliveryInfo = deliveryInfo;
        }

        public Guid UserId { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }

        public OrderDeliveryInfo DeliveryInfo { get; private set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Service
{
    public interface IUserDomainService
    {
   
        bool IsPhoneNumberExist(string phoneNumber);
    }
}

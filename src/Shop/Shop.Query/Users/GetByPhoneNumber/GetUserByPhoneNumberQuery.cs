using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Query.Users.GetByPhoneNumber
{
    public record GetUserByPhoneNumberQuery(string PhoneNumber) : IBaseQuery<UserDto?>;
}

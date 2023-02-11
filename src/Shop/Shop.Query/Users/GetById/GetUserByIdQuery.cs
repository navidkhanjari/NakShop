using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Query.Users.GetById
{
    public class GetUserByIdQuery : IBaseQuery<UserDto?>
    {
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}

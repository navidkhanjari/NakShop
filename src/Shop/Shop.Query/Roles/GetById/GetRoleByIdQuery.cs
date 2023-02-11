using Common.Query;
using Shop.Query.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Roles.GetById
{

    public record GetRoleByIdQuery(Guid RoleId) : IBaseQuery<RoleDto?>;
}

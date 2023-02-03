using Common.Application;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Roles.Create
{
    public record CreateRoleCommand(string Title, List<Permissions> Permissions) : IBaseCommand;
}

using Common.Application;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;


namespace Shop.Application.Roles.Edit
{
    public record EditRoleCommand(Guid Id, string Title, List<Permissions> Permissions) : IBaseCommand;
}

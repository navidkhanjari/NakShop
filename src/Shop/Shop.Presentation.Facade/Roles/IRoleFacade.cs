﻿using Common.Application;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Roles
{

    public interface IRoleFacade
    {
        Task<OperationResult> CreateRole(CreateRoleCommand command);
        Task<OperationResult> EditRole(EditRoleCommand command);

        Task<RoleDto?> GetRoleById(Guid roleId);
        Task<List<RoleDto>> GetRoles();
    }
}

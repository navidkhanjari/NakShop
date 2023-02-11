﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Roles.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Roles.GetList
{
    public class GetRoleListQueryHandler : IBaseQueryHandler<GetRoleListQuery, List<RoleDto>>
    {
        private readonly ShopContext _context;

        public GetRoleListQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.Select(role => new RoleDto()
            {
                Id = role.Id,
                CreationDate = role.CreationDate,
                Permissions = role.Permissions.Select(s => s.Permission).ToList(),
                Title = role.Title
            }).ToListAsync(cancellationToken);
        }
    }
}

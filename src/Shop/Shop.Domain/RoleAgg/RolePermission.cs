using Common.Domain;
using System;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        private RolePermission()
        {

        }
        public RolePermission(Permissions permission)
        {
            Permission = permission;
        }

        public Guid RoleId { get; internal set; }
        public Permissions Permission { get; private set; }
    }
}

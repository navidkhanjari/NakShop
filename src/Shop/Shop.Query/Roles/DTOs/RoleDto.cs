using Common.Query;
using Shop.Domain.RoleAgg;
using System.Collections.Generic;


namespace Shop.Query.Roles.DTOs
{
    public class RoleDto : BaseDto
    {
        public string Title { get; set; }
        public List<Permissions> Permissions { get; set; }
    }
}

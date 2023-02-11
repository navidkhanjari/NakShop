using Common.Query.Filters;
using Shop.Query.Users.DTOs;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Users.GetByFilter
{
    public class GetUserByFilterQuery : BaseQueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {
        }
    }
}

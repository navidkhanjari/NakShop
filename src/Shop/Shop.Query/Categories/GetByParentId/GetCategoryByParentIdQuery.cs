using Common.Query;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Categories.GetByParentId
{
    public record GetCategoryByParentIdQuery(Guid ParentId) : IBaseQuery<List<ChildCategoryDto>>;
}
using Common.Query;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Query.Categories.GetList
{
    public record GetCategoryListQuery : IBaseQuery<List<CategoryDto>>;
}

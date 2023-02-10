using Common.Query;
using Shop.Query.Categories.DTOs;
using System;

namespace Shop.Query.Categories.GetById
{

    public record GetCategoryByIdQuery(Guid CategoryId) : IBaseQuery<CategoryDto>;
}

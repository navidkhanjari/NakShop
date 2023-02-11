using Common.Query;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Query.Products.GetById
{
    public record GetProductByIdQuery(Guid ProductId) : IBaseQuery<ProductDto?>;
}

using Common.Query;
using System;

namespace Shop.Query.Products.DTOs
{
    public class ProductImageDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public string ImageName { get; set; }
        public int Sequence { get; set; }
    }
}

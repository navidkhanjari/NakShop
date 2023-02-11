using Common.Domain.ValueObjects;
using System;

namespace Shop.Query.Products.DTOs
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
    }
}

using Common.Domain.ValueObjects;
using Common.Query;
using System;
using System.Collections.Generic;


namespace Shop.Query.Categories.DTOs
{
    public class ChildCategoryDto:BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public Guid ParentId { get; set; }
        public SeoData SeoData { get; set; }
        public List<SecondaryChildCategoryDto> Childs { get; set; }
    }

}

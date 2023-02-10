﻿using Common.Domain.ValueObjects;
using Common.Query;
using System;


namespace Shop.Query.Categories.DTOs
{
    public class SecondaryChildCategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public Guid ParentId { get; set; }

    }

}

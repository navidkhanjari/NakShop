using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Context;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            if (product == null)
                return null;
            return new()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
                SeoData = product.SeoData,
                Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
                {
                    Value = s.Value,
                    Key = s.Key
                }).ToList(),
                Images = product.Images.Select(s => new ProductImageDto()
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    ImageName = s.ImageName,
                    ProductId = s.ProductId,
                    Sequence = s.Sequence
                }).ToList(),
                Category = new()
                {
                    Id = product.CategoryId
                },
                SubCategory = new()
                {
                    Id = product.SubCategoryId
                },
                SecondarySubCategory = product.SecondarySubCategoryId != null ? new()
                {
                    Id = (Guid)product.SecondarySubCategoryId
                } : null,
            };
        }
        public static ProductFilterData MapListData(this Product product)
        {
            return new ProductFilterData()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title
            };
        }
        public static async Task SetCategories(this ProductDto product, ShopContext context)
        {
            var category = await context.Categories
                .Where(f => f.Id == product.Category.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData,
                    Title = s.Title
                })
                .FirstOrDefaultAsync();

            var subCategory = await context.Categories
                .Where(f => f.Id == product.SubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData,
                    Title = s.Title
                })
                .FirstOrDefaultAsync();

            if (product.SecondarySubCategory != null)
            {
                var secondarySubCategory = await context.Categories
                    .Where(f => f.Id == product.SecondarySubCategory.Id)
                    .Select(s => new ProductCategoryDto()
                    {
                        Id = s.Id,
                        Slug = s.Slug,
                        ParentId = s.ParentId,
                        SeoData = s.SeoData,
                        Title = s.Title
                    })
                    .FirstOrDefaultAsync();

                if (secondarySubCategory != null)
                    product.SecondarySubCategory = secondarySubCategory;
            }


            if (category != null)
                product.Category = category;

            if (subCategory != null)
                product.SubCategory = subCategory;
        }
    }
}

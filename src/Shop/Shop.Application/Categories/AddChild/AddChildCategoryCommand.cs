using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(Guid ParentId, string Title, string Slug, SeoData SeoData) :IBaseCommand<Guid>;
}

using Common.Application;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Categories
{
    public interface ICategoryFacade
    {
        Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);
        Task<OperationResult<Guid>> Create(CreateCategoryCommand command);


        Task<CategoryDto> GetCategoryById(Guid id);
        Task<List<ChildCategoryDto>> GetCategoriesByParentId(Guid parentId);
        Task<List<CategoryDto>> GetCategories();

    }
}

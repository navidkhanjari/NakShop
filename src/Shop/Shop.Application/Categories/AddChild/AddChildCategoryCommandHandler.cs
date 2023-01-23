﻿using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler: IBaseCommandHandler<AddChildCategoryCommand,Guid>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<Guid>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult<Guid>.NotFound();

            category.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
            await _repository.Save();
            return OperationResult<Guid>.Success(category.Id);
        }
    }
}

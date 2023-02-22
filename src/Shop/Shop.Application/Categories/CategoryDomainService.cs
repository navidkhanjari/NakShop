using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories
{
  public  class CategoryDomainService : ICategoryDomainService

    {
        private readonly ICategoryRepository _repository;

        public CategoryDomainService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public bool IsSlugExist(string slug)
        {
            return _repository.Exists(f => f.Slug == slug);
        }
    }
}

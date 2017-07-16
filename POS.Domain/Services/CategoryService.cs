using System;
using System.Collections.Generic;
using POS.Domain.Entities;
using POS.Domain.Interfaces.Repositories;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;

namespace POS.Domain.Services
{
    public class CategoryService : BaseService<Category, CategoryDTO>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDTO> GetAllActive()
        {
            return _categoryRepository.GetAllActive();
        }
    }
}

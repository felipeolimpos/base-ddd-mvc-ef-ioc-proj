using System.Collections.Generic;
using POS.Domain.Entities;
using POS.Domain.Interfaces.Repositories;
using POS.Infra.Cross.DTO;
using System.Linq;
using AutoMapper;

namespace POS.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category, CategoryDTO>, ICategoryRepository
    {
        public IEnumerable<CategoryDTO> GetAllActive()
        {
            var activeCategories = All().Where(c => c.Active).ToList();
            return Mapper.Map<List<CategoryDTO>>(activeCategories);
        }
    }
}

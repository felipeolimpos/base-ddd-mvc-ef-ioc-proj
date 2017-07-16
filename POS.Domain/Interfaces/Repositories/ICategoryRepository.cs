using POS.Domain.Entities;
using POS.Infra.Cross.DTO;
using System.Collections.Generic;

namespace POS.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, CategoryDTO>
    {
        IEnumerable<CategoryDTO> GetAllActive();
    }
}

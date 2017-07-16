using POS.Infra.Cross.DTO;
using System.Collections.Generic;

namespace POS.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        IEnumerable<CategoryDTO> GetAllActive();
    }
}

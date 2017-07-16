using POS.Infra.Cross.DTO;
using System.Collections.Generic;

namespace POS.Domain.Interfaces.Services
{
    public interface IProductService : IBaseService<ProductDTO>
    {
        IEnumerable<ProductDTO> GetAllActive();
        IEnumerable<ProductDTO> GetActiveByCategory(int categoryId);
    }
}

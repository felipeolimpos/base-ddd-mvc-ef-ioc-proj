using POS.Domain.Entities;
using POS.Infra.Cross.DTO;
using System.Collections.Generic;

namespace POS.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, ProductDTO>
    {
        IEnumerable<ProductDTO> GetAllActive();
        IEnumerable<ProductDTO> GetActiveByCategory(int categoryId);
    }
}

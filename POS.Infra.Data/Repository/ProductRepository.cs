using AutoMapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces.Repositories;
using POS.Infra.Cross.DTO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace POS.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product, ProductDTO>, IProductRepository
    {
        public IEnumerable<ProductDTO> GetActiveByCategory(int categoryId)
        {
            var activeCategories = All().Where(c => c.Active && c.CategoryId.Equals(categoryId)).ToList();
            return Mapper.Map<List<ProductDTO>>(activeCategories);
        }

        public IEnumerable<ProductDTO> GetAllActive()
        {
            var activeCategories = All().Where(c => c.Active).ToList();
            return Mapper.Map<List<ProductDTO>>(activeCategories);
        }
    }
}

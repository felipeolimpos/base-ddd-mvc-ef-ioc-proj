using POS.Domain.Entities;
using POS.Domain.Interfaces.Repositories;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;
using System.Collections.Generic;
using System;

namespace POS.Domain.Services
{
    public class ProductService : BaseService<Product, ProductDTO>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetActiveByCategory(int categoryId)
        {
            return _productRepository.GetActiveByCategory(categoryId);
        }

        public IEnumerable<ProductDTO> GetAllActive()
        {
            return _productRepository.GetAllActive();
        }
    }
}

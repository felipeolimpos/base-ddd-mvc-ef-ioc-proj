using System;
using System.Collections.Generic;

namespace POS.Infra.Cross.DTO
{
    public class CategoryDTO : IEntityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<ProductDTO> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public virtual IEnumerable<ProductViewModel> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
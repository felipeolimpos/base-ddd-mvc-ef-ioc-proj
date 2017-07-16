using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is required.")]
        public string Description { get; set; }

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public CategoryViewModel Category { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }
    }
}
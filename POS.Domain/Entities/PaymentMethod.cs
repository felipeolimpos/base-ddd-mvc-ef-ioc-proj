using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}

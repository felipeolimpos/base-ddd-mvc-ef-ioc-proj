using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels
{
    public class PaymentMethodViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
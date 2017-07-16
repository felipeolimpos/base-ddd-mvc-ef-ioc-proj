using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "Billing Info")]
        public string BillingInfo { get; set; }
        [Required]
        [Display(Name = "Shipping Info")]
        public string ShippingInfo { get; set; }
        public CartViewModel Cart { get; set; }
        [Required]
        [Display(Name = "Payment Method")]
        public int PaymentMethodId { get; set; }
        public List<PaymentMethodViewModel> PaymentMethods { get; set; }
    }
}
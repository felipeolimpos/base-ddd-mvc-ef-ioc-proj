using System.ComponentModel.DataAnnotations;

namespace POS.Web.ViewModels
{
    public class CartItemViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total
        {
            get { return Product.Price * Quantity; }
        }

    }
}
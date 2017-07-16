using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POS.Web.ViewModels
{
    public class CartViewModel
    {
        public IList<CartItemViewModel> Items { get; set; }
        public decimal Quantity
        {
            get { return Items == null ? 0 : Items.Sum(i => i.Quantity); }
        }
        [DataType(DataType.Currency)]
        public decimal Total
        {
            get { return Items == null ? 0 : Items.Sum(i => i.Total); }
        }

    }
}
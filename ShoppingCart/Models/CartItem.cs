using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Item
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }

        [DisplayName("Price (€):")]
        public double Price { get; set; }
    }

    public class CartItem : Item
    {
        public int Quantity { get; set; }
    }
}

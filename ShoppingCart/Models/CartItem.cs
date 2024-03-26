using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Item
    {
        [Key]
        public String Code { get; set; }
        public String Description { get; set; }
        [Display(Name = "Price (€)")]
        public Double Price { get; set; }
    }

    public class CartItem : Item
    {
        public int Quantity { get; set; }
    }
}

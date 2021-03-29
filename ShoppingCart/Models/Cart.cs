using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Cart
    {
        private List<CartItem> items;

        public Cart()
        {
            items = new List<CartItem>();
        }

        public void AddItem(Item choice)
        {
            CartItem found = items.FirstOrDefault(p => p.Code.ToUpperInvariant() == choice.Code.ToUpperInvariant());
            if (found!=null)
            {
                found.Quantity++;
            }
            else
            {
                items.Add(new CartItem() { Code = choice.Code, Description = choice.Description, Price = choice.Price, Quantity = 1 });
            }
        }

        public double CalculateTotal()
        {
            return items.Sum(p => p.Price * p.Quantity);
        }
    }
}

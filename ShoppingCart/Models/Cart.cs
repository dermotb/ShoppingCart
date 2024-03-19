using System.Globalization;

namespace ShoppingCart.Models
{
    public class Cart
    {
        private List<CartItem> items;

        public Cart() 
        {
            items = new List<CartItem>();
        }

        public void AddItem(Item item) 
        {
            var match = items.FirstOrDefault(i=>i.Code.ToUpper(CultureInfo.CurrentCulture) == item.Code.ToUpper(CultureInfo.CurrentCulture));
            if (match != null) 
            {
                match.Quantity++;
            }
            else
            {
                items.Add(new CartItem { Code = item.Code,Description=item.Description, Price=item.Price, Quantity=1 });
            }
        }

        public double CalculateTotalPrice()
        {
            return items.Sum(p => p.Price * p.Quantity);
        }
    }
}

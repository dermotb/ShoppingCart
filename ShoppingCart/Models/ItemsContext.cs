using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{

    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions<ItemsContext> options) :base(options)
        {
        }


        public DbSet<Item> products { get; set; }
    }
}
